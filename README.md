# MSQS
Test MSMQ and SignalR in Windows Service and WinForm

**1: Install Message Queue server**![enter image description here](https://github.com/parisgo/MSQS/blob/master/docs/images/01.png?raw=true)

**2: Debug projects**   
>* Start project "MSQS.Service" for debug Service
>* Start project "MSQS.Sender for debug UI Sender
>* Start project "MSQS.Client" at 2 times for debug UI Client

![enter image description here](https://github.com/parisgo/MSQS/blob/master/docs/images/02.png?raw=true)

**3: Install windows service**    
We could use command for install service :
```
sc create MSQS-Test displayname="MSQS Test" binpath=C:\Users\xyu\Desktop\MSQS-master\MSQS-master\MSQS.Service\bin\Release\MSQS.Service.exe
```
and start this service 
![enter image description here](https://github.com/parisgo/MSQS/blob/master/docs/images/03.png?raw=true)

and test it like before
![enter image description here](https://github.com/parisgo/MSQS/blob/master/docs/images/04.png?raw=true)
