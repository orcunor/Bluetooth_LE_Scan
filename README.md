![bleorcunnnnn](https://user-images.githubusercontent.com/52966278/124142847-46ee4480-da93-11eb-940f-fb048e70a4df.PNG)

# Bluetooth_LE_Scan
This app uses UWP namespaces and sdk, so you must install it in visual studio installer in order to run the app..

A sample winforms app that notify , indicate, write, read a value from a bluetoothLE device characterictics.


# Sample of UUID'S :

 Service UUID = 6144 ** 0x1800,  
Characeristic UUID =   10752 - Device Name  ,  10753  - Appearance ,
**  Properties : Read **

 Service UUID = 6154, **    
Characeristic UUID =   10790 - Firmware Revision String   ,
10791- Hardware Revision String  ,
10792 - Software Revision String ,
10793-Manufactırer Name String  ,
10788 - Model Number String  ,
10789 -Serial Number String  ,
10787 - System Id   10794 - empty ,
Properties : Read

 Service UUID = 21315,  
 Characeristic UUID = 21315  
 ** Properties :  Write, Notify ,WriteWithoutResponse,Indicate **
 (This is about RN4870/71 Microchip)

