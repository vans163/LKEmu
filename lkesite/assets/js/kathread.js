function messageHandler(event) {
    // Accessing to the message data sent by the main page
    var mSent = event.data;
    
	if (mSent == "start")
	{
		KeepAliveLoop();
	}
	
 //   var messageReturned = "Hello " + messageSent + " from a separate thread!";
 //   this.postMessage(messageReturned);
}

function KeepAliveLoop()
{
	this.postMessage("ping");
	setTimeout(KeepAliveLoop, 4000);
}

// Defining the callback function raised when the main page will call us
this.addEventListener('message', messageHandler, false);