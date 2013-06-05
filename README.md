LKEmu
======

C# Emulator /w Tools for mmorpg classic The Last Kingdom.

[devTool]:
devTool is a tool to assist with reverse engineering the game.
Run devTool then run the game client and login to emulate a session.
Send packets using the devTool GUI. 
Binary packet handler addresses are listed in devTool/Server/Packets/packetlist.txt.

Ignore the psuedo packet structure, that was a failed idapython attempt.




[VIF]:
very import files folder. Use these to save time REing.

	ClientWindowed2.exerename is the binary. Rename it to .exe.
	
	ClientWindowed2.idc is a IDC script for IDA with Dephi names from IDR.
	
	http://www.speedyshare.com/NfFYr/ClientWindowed2.idb IDB for IDA with some naming




[FileReader]:
FileReader is a tool to attempt at reverse engineering the .atz and other file formats the game uses, with hope to create a sprite editor / map editor / etc.




[lkesite]:
Website source with the webtrader.

To enable webtrader set the IP and PORT in the trader.html inside the function

	function connectWebsocket() {..
	
to your external IP and the port you using for webtrader in LKCamelot.


[LKCamelot]:
LKCamelot is the main server, if you just want to run the game this is all you need.
Packets still need to be documented.
The code is really poor and hacky in many parts.
Async listener 'borrowed' from Mooege.
Packet stream + reader/writer 'borrowed' from RunUO, credits to the great guys and gals over there.
LKCamelot runs on Mono.


To run the server:

	Server.cs 178:     int Port = 43333; 

this is the port you want the server to run on. Make sure your firewall / router has this port open for TCP

	web/wslistener.cs 24:   ..("ws://localhost:43332/webtrader"); 

This is the port used for the web auction house.  Make sure it is open as well.





Navigating:

Server.cs starts the async listener. At line 187 the data stream is read and all packets are passed to the packet handler.

	((IOClient)connection.Client).Parse(e);


line 65 in io/IOClient.cs

	HandleIncoming(packet);

Handles incoming packets


model/World/World.cs holds the static world state responsible for spawning monsters, sending messages to all players, moving stuff, etc.

script/  holds all the static declarations for mobs and items, etc.


ALOT OF CODE IS REALLY BAD I AM SORRY! PLEASE DONT HATE ))
