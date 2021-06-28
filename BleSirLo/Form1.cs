using SDKTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;

namespace BleSirLo
{
    public partial class Bluetooth_LE : Form
    {

        private List<DeviceInformation> UnknownDevices = new List<DeviceInformation>();
        private List<DeviceInformation> _knownDevices = new List<DeviceInformation>();
        private IReadOnlyList<GattCharacteristic> characteristics;
        private IReadOnlyList<GattDeviceService> services;
        private BluetoothLEDevice currentBluetoothLeDevice;


        private GattDeviceService currentSelectedService = null;
        private GattCharacteristic currentSelectedCharacteristic = null;

        private DeviceWatcher deviceWatcher;

        public Bluetooth_LE()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            ConnectBtn.Enabled = false;
            DisConnectBtn.Enabled = false;

            //empty bluetooth inputs
           // DevicesComboBox.Items.Clear();

            CharacteristicsTxtBox.Clear();
            ServiceTxtBox.Clear();

            //empty devices list
            //_knownDevices.Clear();
           // UnknownDevices.Clear();

           

        }

        private void StartBleDeviceWatcher()
        {
            // Additional properties we would like about the device.
            // Property strings are documented here https://msdn.microsoft.com/en-us/library/windows/desktop/ff521659(v=vs.85).aspx
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected", "System.Devices.Aep.Bluetooth.Le.IsConnectable" };

            // BT_Code: Example showing paired and non-paired in a single query.
            string aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

            deviceWatcher =
                    DeviceInformation.CreateWatcher(
                        aqsAllBluetoothLEDevices,
                        requestedProperties,
                        DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            deviceWatcher.Added += DeviceWatcher_Added;
            //deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            //deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start over with an empty collection.
            _knownDevices.Clear();
            deviceWatcher.Start();
        }

        private void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
        {
            Respond(args.ToString() + " Stopped");
        }

        private void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate deviceInfo)
        {
            foreach (var device in _knownDevices)
            {
                if (device.Id == deviceInfo.Id)
                {
                    //Respond(device.Name + " Removed");
                    DevicesComboBox.Items.Remove(device.Name);
                    _knownDevices.Remove(device);
                    return;
                }
            }
            // Respond(deviceInfo.Id + " Removed");
        }

        private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate deviceInfo)
        {
            foreach(var device in _knownDevices)
            {
                if(device.Id == deviceInfo.Id)
                {
                    Respond(device.Name + " Updated");
                    return;
                }
            }
            Respond(deviceInfo.Id + " Updated");
        }

        private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {
            //if (sender == deviceWatcher)
            //{
            //    Respond("Device Enumeration Completed");
            //    Respond($" {DevicesComboBox.Items.Count} Devices found");
            //    ScanBtn.Enabled = true;
            //    ConnectBtn.Enabled = true;

            //    if (DevicesComboBox.Items.Count > 0)
            //        DevicesComboBox.SelectedIndex = 0;
            //}

        }

        private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            //Debug.WriteLine(String.Format("Device Found!" + Environment.NewLine + "ID:{0}" + Environment.NewLine + "Name:{1}", deviceInfo.Id, deviceInfo.Name));
            //notify user for every device that is found
            //Respond(String.Format("Device Found!" + Environment.NewLine + "ID:{0}" + Environment.NewLine + "Name:{1}", deviceInfo.Id, deviceInfo.Name));

            try
            {

                if (deviceInfo != null)
                {
                    if (!string.IsNullOrEmpty(deviceInfo.Name))
                    {
                        //if (deviceInfo.Name.ToUpper().StartsWith("STOCKARTSCAN") || deviceInfo.Name.ToUpper().StartsWith("MEDNEST"))
                        //{
                            if (!_knownDevices.Exists(x => x.Id == deviceInfo.Id || x.Name == deviceInfo.Name))
                            {
                                _knownDevices.Add(deviceInfo);
                                DevicesComboBox.Items.Add(deviceInfo.Name);
                            }
                            else
                            {
                                UnknownDevices.Add(deviceInfo);
                            }
                        //}
                    }
                }
                
            }
            catch (System.Exception ex) { Respond("Exception Handled -> DeviceWatcher_Added: " + ex); }

           
        }

        //trigger StartBleDeviceWatcher() to start bluetoothLe Operation
        private void ScanBtn_Click(object sender, EventArgs e)
        {
            //empty bluetooth inputs
            //DevicesComboBox.Items.Clear();
            CharacteristicsTxtBox.Clear();
            ServiceTxtBox.Clear();

            //empty devices list
            //_knownDevices.Clear();
            //UnknownDevices.Clear();

            //notify user
           
            Respond("Scanning nearby devices...");

            //disable scan button
            ScanBtn.Enabled = false;
            ConnectBtn.Enabled = true;
            DisConnectBtn.Enabled = false;
            //finally, start scanning
            StartBleDeviceWatcher();
        }
        //function that handles printing messages to the textbox
        public void Respond(string message)
        {
            //add spacing if there is already data
            if(Response.Text != "")
            {
                Response.AppendText(Environment.NewLine + Environment.NewLine);
            }
            //append text to current text
            Response.AppendText(message);
            //scroll to the bottom most
            Response.ScrollToCaret();
        }
        //function that handles the connect click event when there is a selected device
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (DevicesComboBox.SelectedIndex != -1 && ServiceTxtBox.Text != "" && CharacteristicsTxtBox.Text != "")
            {
                //start connecting to device
                ConnectDevice(_knownDevices[DevicesComboBox.SelectedIndex].Name);

            }
            else
            {
                //conditions not met
                Respond("Please select a device and fill up characterics and services textbox!");
            }
        }
        private async void ConnectDevice(string deviceName)
        {
            try
            {
                ConnectBtn.Enabled = false;


                Respond("Connecting to device...");
                var deviceInstance = _knownDevices.FirstOrDefault(x => x.Name == deviceName);


                //get bluetooth device information
                currentBluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInstance.Id);
                //Respond(bluetoothLeDevice.ConnectionStatus.ToString());

                //get its services
                GattDeviceServicesResult result = await currentBluetoothLeDevice.GetGattServicesAsync();

                //verify if getting success 
                if (result.Status == GattCommunicationStatus.Success)
                {
                    //store device services to list
                    services = result.Services;

                    //loop each services in list
                    foreach (var serv in services)
                    {
                        //get serviceName by converting the service UUID
                        string ServiceName = Utilities.ConvertUuidToShortId(serv.Uuid).ToString();

                        //if current servicename matches the input service name
                        if (ServiceName.ToString() == ServiceTxtBox.Text.ToString())
                        {
                            //notify the user that it found the service
                            Respond("Service found...");

                            //store the current service
                            currentSelectedService = serv;

                            //get the current service characteristics
                            GattCharacteristicsResult resultCharacterics = await currentSelectedService.GetCharacteristicsAsync();

                            //verify if getting characteristics is success 
                            if (resultCharacterics.Status == GattCommunicationStatus.Success)
                            {
                                //store device services to list
                                characteristics = resultCharacterics.Characteristics;

                                //loop through its characteristics
                                foreach (var chara in characteristics)
                                {
                                    //get CharacteristicName by converting the current characteristic UUID
                                    string CharacteristicName = Utilities.ConvertUuidToShortId(chara.Uuid).ToString();

                                    //if current CharacteristicName matches the input characteristic name
                                    if (CharacteristicName.ToString() == CharacteristicsTxtBox.Text.ToString())
                                    {
                                        //notify the user that it found the characteristicName
                                        Respond("Characteristic found...");

                                        //store the current characteristic
                                        currentSelectedCharacteristic = chara;

                                        //notify the user that it has connected successfully to the device
                                        Respond("Connected Successfully!");
                                        labelConnectedStatus.ForeColor = System.Drawing.Color.Blue;
                                        labelConnectedStatus.Text = "Connected to " + DevicesComboBox.SelectedItem.ToString() + " at " + DateTime.Now.ToLongTimeString();
                                        ConnectBtn.Enabled = false;
                                        DisConnectBtn.Enabled = true;
                                        //stop method execution
                                        return;
                                    }
                                }
                                //notify that no characteristicname matched the input characteristic
                                Respond("Characteristic not found...");
                            }
                            else
                            {
                                //notify the user that it has problem getting current service characteristics
                                Respond("Unable to get device service characterics!");
                            }
                        }
                    }
                    //notify that no servicename matched the input service
                    Respond("Service not found...");
                }
                else
                {
                    //notify the user that it has problem getting its services
                    Respond("Unable to get device services!");
                }

                //if unable to connect set enable connectbtn again
                
                //disable connect button
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
        //function that handles write event
        private async void WriteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentSelectedService != null && currentSelectedCharacteristic != null)
                {
                    GattCharacteristicProperties properties = currentSelectedCharacteristic.CharacteristicProperties;
                    if (properties.HasFlag(GattCharacteristicProperties.Write))
                    {
                        var writer = new DataWriter();

                        var startCommand = Encoding.ASCII.GetBytes(InputTxtBox.Text);
                        writer.WriteBytes(startCommand);


                        //var command = Convert.ToInt64(InputTxtBox.Text, 16);
                        //writer.WriteInt64(command);


                        GattCommunicationStatus result = await currentSelectedCharacteristic.WriteValueAsync(writer.DetachBuffer());
                        if (result == GattCommunicationStatus.Success)
                        {
                            //labelConnectedStatus.ForeColor = System.Drawing.Color.Green;
                            //labelConnectedStatus.Text = "Meesage sent successfully to " + DevicesComboBox.SelectedItem.ToString() + " at " + DateTime.Now.ToLongTimeString();
                            Respond("message sent successfully ");
                        }
                        else
                        {
                            //labelConnectedStatus.ForeColor = System.Drawing.Color.Red;
                            //labelConnectedStatus.Text = "Error encountered on writing to characteristic! " + DevicesComboBox.SelectedItem.ToString() + " at " + DateTime.Now.ToLongTimeString();
                            Respond("Error encountered on writing to characteristic!");
                        }
                    }
                    else
                    {
                        //labelConnectedStatus.ForeColor = System.Drawing.Color.Red;
                        //labelConnectedStatus.Text = "No write property for this characteristic! " + DevicesComboBox.SelectedItem.ToString() + " at " + DateTime.Now.ToLongTimeString();
                        Respond("No write property for this characteristic!");
                    }
                }
                else
                {
                    //labelConnectedStatus.ForeColor = System.Drawing.Color.Red;
                    //labelConnectedStatus.Text = "Please connect to a device first! " + DevicesComboBox.SelectedItem.ToString() + " at " + DateTime.Now.ToLongTimeString();
                    Respond("Please connect to a device first!");
                }
            }
            catch (Exception)
            {
            }

            
        }
        //if devices change disconnect
        private void DevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSelectedService = null;
            currentSelectedCharacteristic = null;
            ConnectBtn.Enabled = true;
            DisConnectBtn.Enabled = false;
            CharacteristicsTxtBox.Clear();
            ServiceTxtBox.Clear();
        }
        //function that handles the read button event
        private async void ReadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentSelectedService != null && currentSelectedCharacteristic != null)
                {
                    GattCharacteristicProperties properties = currentSelectedCharacteristic.CharacteristicProperties;

                    //if selected characteristics has read property
                    if (properties.HasFlag(GattCharacteristicProperties.Read))
                    {
                        //read value asynchronously
                        GattReadResult result = await currentSelectedCharacteristic.ReadValueAsync();
                        if (result.Status == GattCommunicationStatus.Success)
                        {
                            var reader = DataReader.FromBuffer(result.Value);
                            byte[] input = new byte[reader.UnconsumedBufferLength];
                            reader.ReadBytes(input);
                            Respond(Encoding.ASCII.GetString(input));
                            
                        }
                        else
                        {
                            Respond("Error encountered on read characteristic value!");
                        }
                    }
                    else
                    {
                        Respond("No read  property for this characteristic!");
                    }
                }
                else
                {
                    Respond("Please connect to a device first!");
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private void GattCharacteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            var reader = DataReader.FromBuffer(args.CharacteristicValue);
            byte[] input = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(input);
            Respond(Encoding.ASCII.GetString(input));
            Respond("okudummm");
        }
        private void DisConnect()
        {
            try
            {
                if (currentBluetoothLeDevice != null)
                {
                    currentBluetoothLeDevice.Dispose();
                    currentBluetoothLeDevice = null;
                }
                if (currentSelectedCharacteristic != null)
                {
                   
                    currentSelectedCharacteristic.Service.Dispose();
                    currentSelectedCharacteristic = null;
                    currentSelectedService = null;


                }
                labelConnectedStatus.ForeColor = System.Drawing.Color.Red;
                labelConnectedStatus.Text = "DisConnected ";
                ConnectBtn.Enabled = true;
                btnRefresh.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void DisConnectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DisConnect();
                NotifyBtn.Enabled = true;
                IndicateBtn.Enabled = true;
            }
            catch (Exception){}
        }
        private void GetDevices()
        {
            try
            {
                DevicesComboBox.Items.Clear();
                DevicesComboBox.Items.AddRange(GetBluetoothLEDevices().ToArray());

                if (DevicesComboBox.Items.Count > 0)
                    DevicesComboBox.SelectedIndex = 0;

                this.Text = "BluetoothLE Test (" + DevicesComboBox.Items.Count.ToString() + ") devices founded";
            }
            catch (Exception ex) {  }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                

                GetDevices();
                if (currentBluetoothLeDevice != null)
                {
                    if (currentSelectedCharacteristic != null && currentSelectedService != null)
                    {
                        
                    }
                }
                else
                {
                    this.ConnectDevice(_knownDevices[DevicesComboBox.SelectedIndex].Name);
                }

                
            }
            catch (Exception)
            {
            }
        }
        public List<string> GetBluetoothLEDevices()
        {
            try
            {
                return _knownDevices.Select(x => x.Name).ToList();
            }
            catch (System.Exception ex)
            {
               
                throw ex;
            }
        }
        private async void NotifyBtn_Click(object sender, EventArgs e)
        {
            if (currentSelectedService != null && currentSelectedCharacteristic != null)
            {
                GattCharacteristicProperties properties = currentSelectedCharacteristic.CharacteristicProperties;

                //if selected characteristics has read property
                if (properties.HasFlag(GattCharacteristicProperties.Notify))
                {
                    //read value asynchronously
                    GattCommunicationStatus communicationStatus = await currentSelectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
                    if (communicationStatus == GattCommunicationStatus.Success)
                    {
                        currentSelectedCharacteristic.ValueChanged += GattCharacteristic_ValueChanged;
                        Respond("Successfully to Notify");
                        NotifyBtn.Enabled = false;
                        IndicateBtn.Enabled = false;
                    }
                    else
                    {
                        Respond("Error encountered on notify characteristic value!");
                    }
                }
                else
                {
                    Respond("No notify property for this characteristic!");
                }
            }
            else
            {
                Respond("Please connect to a device first!");
            }



        }
        private async void IndicateBtn_Click(object sender, EventArgs e)
        {
            if (currentSelectedService != null && currentSelectedCharacteristic != null)
            {
                GattCharacteristicProperties properties = currentSelectedCharacteristic.CharacteristicProperties;

                
                if (properties.HasFlag(GattCharacteristicProperties.Indicate))
                {
                    
                    GattCommunicationStatus communicationStatus = await currentSelectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Indicate);

                    if (communicationStatus == GattCommunicationStatus.Success)
                    {
                        currentSelectedCharacteristic.ValueChanged += GattCharacteristic_ValueChanged;
                        Respond("Successfully to Indicate ");
                        IndicateBtn.Enabled = false;
                        NotifyBtn.Enabled = false;
                    }
                    else
                    {
                        Respond("Error encountered on indicate characteristic value!");
                    }
                }
                else
                {
                    Respond("No indicate property for this characteristic!");
                }
            }
            else
            {
                Respond("Please connect to a device first!");
            }

        }
    }
}
