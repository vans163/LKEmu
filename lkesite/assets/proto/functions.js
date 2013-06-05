// JavaScript Document
function loadFancyBox(url)
{
	$.fancybox({
		'href'			:	url,
		'transitionIn'	:	'elastic',
		'transitionOut'	:	'elastic',
		'width'			:	'auto',
		'height'		:	'auto'
			});
}
function Search(code)
{
	if(code.indexOf("?") != -1 || code.indexOf(";") != -1)
	{
		code = code.replace("?", "");
		code = code.replace(";",""); 
		$("#searchcustomer").val(code);
	}
	if(code=='')
	{
		$("#searchcustomer").css("border","1px solid #F00");
		$("#error").html("<div style='text-align:left;padding-left:30px;'>Please enter customer unique ID or<br>Search by:<br><div style='padding-left:30px;'>SIN number<br>Driver licence<br>Passport number<br>Birth date (dd-mm-yyyy)<br>First or Last name (no space)</div></div>").show('slow');
		return false;
	}
	
	$("#error").html('');
	var storeid	= $("#storeid").val();
	var data	= "uid="+code+"&storeid="+storeid;
	//document.checkid.searchdata.value = code;
	
	$('#searchdetails').html("<img src='images/loading.gif' />");
	$('#rightdetails').html("<img src='images/loading.gif' />");
	
	//document.checkid.submit();
	
	$.ajax({
			type:	'POST',
			data:	data,
			url: 	'searchcustomer.php',
			success:function(res)
			{
			 document.getElementById("tablehistory").style.visibility = "show";	
				var obj = JSON.parse(res);
			
				//alert(obj.doctype);
				$("#searchdetails").html(obj.leftcontent);
				$("#rightdetails").html(obj.rightcontent);
				$("#flagged").html(obj.flagged);
				$("#passed").html(obj.passed);
				$("#atRisk").html(obj.atRisk);
				$("#documtype").html(obj.doctype);
				$("#tablehistory").html(obj.tablehistory);
				$("#tablehistory").hide();  //.hide();s show()
			}
		});
		
		
		
}