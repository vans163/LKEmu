<?php
ini_set('display_errors', 0);

require_once("include/config.php");
require_once("pog/function.php");
require_once("pog/class.distance.php");
require_once("pog/distance.php");
require_once("pog/scoreweight.php");
//============creating distance class object===========================//
$distance 		= new Distance();
$distance->setEarthRadius('km');
$passed			=	0;
$atRisk			=	0;
$flagged = 0;
$booldonotlend = false;
//$_POST['uid'] = "M16617856460531"; // Miller  d34444567345678   M16617856460531
//=====================================================================//
$cuniqueid		=	$_POST['uid'];

$searchValue = getSearchCriteria($cuniqueid); 
//var_dump($searchValue);
$storeid		= 	isset($_POST['storeid'])?$_POST['storeid']:$_SESSION['storeid'];

$query			=	"select c.*,l.* from tblcustomer as c 
					left join tblloan as l on c.pkcustomerid =l.fkcustomerid
					where " . $searchValue['searchcode'] . " order by l.datecreated";

	$customerData	=	$db_obj->Query($query,true);
	
	$totalLoanAmount = 0;
	$totalloans = count($customerData);
	$totalLoanAmount = 0;
	$totalunpaidloans = 0;
	
	foreach ($customerData as $row)
	{
		if ($row->outstandingcurrentamount > 0)
		{
			$totalLoanAmount = $totalLoanAmount+$row->outstandingcurrentamount;
			$totalunpaidloans++;	
		}
	}

	$custAddress = $customerData[0]->currentaddress.
	", ".$customerData[0]->customerzipcode.
	", ".$customerData[0]->customercity;


include('pog/SimpleImage.php');

if ($_FILES["textPhoto"])
{
	if ($_FILES["txtUserPhoto"]["error"] > 0)
  		echo "Error: " . $_FILES["txtUserPhoto"]["error"] . "<br>";
   
    if (!empty($_FILES['txtUserPhoto']['tmp_name'])) 
    {
    	
	var_dump($_POST['uid']);
	die;	
		
    	$tempFile 		=	$_FILES['txtUserPhoto']['tmp_name'];
		$file_name		=	$_FILES['txtUserPhoto']  ['name'];
		$info			=	 pathinfo($file_name);
		$allowext		= 	array("jpg","gif","png");
 
		if(in_array($info['extension'],$allowext))
		{
			$file_name = $userid . "." . $info['extension'];
			
			if($file_name == '')				
				$error		=	"Invalid File Name";
		
			$targetPath 			=	DIR_ROOT . 'temp/';
			
			if(!is_dir($targetPath))
				@mkdir($targetPath);
			
			$targetFile 			=	str_replace('//','/',$targetPath) . $file_name;
			$detinationPath 			=	DIR_ROOT . 'images/userphoto/' . $file_name;
			$detinationthumb 			=	DIR_ROOT . 'images/userphoto/thumb/' . $file_name;
			if(move_uploaded_file($tempFile,$targetFile))
			{	
					// resize image to 200x200 px.
				$image = new SimpleImage();
				$image->load($targetFile);
				$image->resizeToWidth(400);
				//$image->resizeToHeight(200);
				$image->save($detinationPath);
				
				// resize image to 30x30 px.
				$image->load($targetFile);
				$image->resizeToWidth(120);
				$image->resizeToHeight(150);
				$image->save($detinationthumb);
					
				list($width, $height, $type, $attr) = getimagesize($detinationPath);	
			}	
			else 
			{
			}		
		} 
		else 
		{		
			$error	=	"Image format is wrong";
		}	
	}
}

// Find duplicate records for SIN, driver licence, passport, e-mail, phone, mobile, Firsr and Last name, postal code, Bith day, address, previous address, 
// (select count(pkloanid) from tblloan where fkcustomerid = c1.fkcustomerid) as tloans
$queryHistory			= 	"SELECT distinct c1.* 
					FROM tblcustomer c
					INNER JOIN tblcustomer c1 
					ON 1=0";
				if($customerData[0]->socialinsurance) 	$queryHistory .=	" OR c.socialinsurance = c1.socialinsurance"; 
				if($customerData[0]->passport)		$queryHistory .=	" OR c.passport = c1.passport"; 
				if($customerData[0]->licence)		$queryHistory .=	" or c.licence = c1.licence";					
				if($customerData[0]->customeremail)	$queryHistory .=	" or c.customeremail = c1.customeremail";
				
				$queryHistory .=	" WHERE " . $searchValue['searchcode'] . " order by c1.pkcustomerid DESC";  // c.licence = 'd34444567345678'

$customerHistory	=	$db_obj->Query($queryHistory,true);

$historyRecords = count($customerHistory);

//var_dump($customerHistory);

	// build table with duplicate resdults
	$customerHistoryTable = "<p style='font-size:18px;margin: 5px;'> List of dublicate records <span style='float:right;font-size:12px;'><a href=\"javascript:void()\" onclick='$(\"#tablehistory\").hide();'> close</a></span></p>";
	$customerHistoryTable .= "<table width='1200'><tr bgcolor='#A9BCF5'>
	<th>UID</th>
	<th>Name</th>
	<th>SIN</th>
	<th>Licence</th>
	<th>Passport</th>
	<th>Home Phone</th>
	<th>Employer</th>
	<th>Birthday</th>
	<th>Loans</th>
	<th>Address</th>
	</tr>";
	/*
	$customerHistoryTable .= "<tr bgcolor='#FAF8DC'>
	<td> ".$customerData[0]->pkcustomerid.".".$customerData[0]->customerfirstname." ".$customerData[0]->customerlastname."</td>
	<td>".$customerData[0]->socialinsurance."</td>
	<td>".$customerData[0]->licence."</td>
	<td>".$customerData[0]->passport."</td>
	<td>".$customerData[0]->customerphone."</td>
	<td>".$customerData[0]->customermobile."</td>
	<td>".$customerData[0]->currentemployer."</td>
	<td>".date('d-m-Y',$customerData[0]->customerdob)."</td>
	</tr>";
	 */
	
	foreach($customerHistory as $cust)
	{
		//Color marker if data is not same
		if($customerData[0]->socialinsurance != $cust->socialinsurance){ $bgsocialinsurance = "bgcolor='red'"; } else {$bgsocialinsurance = "";}
		if($customerData[0]->licence != $cust->licence){ $bglicence = "bgcolor='red'"; } else {$bglicence = "";}
		$bgpassport = compareCustomerData($customerData[0]->passport, $cust->passport, 'red');
		if($customerData[0]->customerfirstname != $cust->customerfirstname
			|| $customerData[0]->customerlastname != $cust->customerlastname){ $bgname = "bgcolor='orange'"; } else {$bgname = "";}
		$bgemployer = compareCustomerData($customerData[0]->currentemployer, $cust->currentemployer, 'orange');	
		//echo "data: " . $cust->pkcustomerid . "<br>";	
		$customerHistoryTable .= "<tr>
		<td>".$cust->pkcustomerid."</td>
		<td ".$bgname."> ".$cust->customerfirstname." ".$cust->customerlastname."</td>
		<td ".$bgsocialinsurance.">".SINformat($cust->socialinsurance)."</td>
		<td ".$bglicence.">".Licenceformat($cust->licence)."</td>
		<td ".$bgpassport.">".$cust->passport."</td>
		<td>".Phoneformat($cust->customerphone)."</td>

		<td ".$bgemployer.">".$cust->currentemployer."</td>
		<td>".date('d-m-Y',$cust->customerdob)."</td>
		<td>".$cust->tloans."</td>
		</tr>";
		
	}
	$customerHistoryTable .= "</table>";
	//echo $customerHistoryTable;
//die;



if(count($customerData)>0)
{
	//==================================================================================================================================//
	//$totalinquired		=	$db_obj->Count('tblinquiry',"fkcustomerid='".$customerData[0]->pkcustomerid."'");
	$totalinquired		=	$customerData[0]->inquires;
	$storeData			=	$db_obj->GetList('tblstore','*',"pkstoreid='".$storeid."'");
	$dob				=	!empty($customerData[0]->customerdob)? date(DATEFORMATE,$customerData[0]->customerdob):"";
	$totalloans			=	isset($totalloans)? $totalloans:"0";

	//======================================================Distanc in Km======================================================//
	//$distanceKm 		= 	$distance->distance_two_point ($customerData[0]->currentaddress, $storeData[0]->storeaddress);
	$age				=	date("Y",time())-date("Y",$customerData[0]->customerdob);
	//=====================================================Points Calculation=================================================//
	$criteria			=	array();
	$fiels				=	$db_obj->GetList('tblcriteriafields','pkcriteriafieldsid,fieldalias');
	$criteria['1']		=	$age;
	$criteria['2']		=	45; //$distanceKm;
	foreach($fiels as $field)
	{
		if($field->fieldalias !='')
		{
			$customerField	=	$field->fieldalias;
			$criteria[$field->pkcriteriafieldsid]=$customerData[0]->$customerField; 	
		}
	}
	
	foreach($criteria as $key => $value)
	{
		$points			=	$db_obj->GetList('tblcriteriapoints','points',"fkcriteriafieldsid='".$key."' and ( ".$value." between minvalue and maxvalue)");
		$totalPoints	=	$totalPoints+$points[0]->points;
		$totalPoints1 = 100;
	}	
	$riskLevelData		=	$db_obj->GetList('tblrating','ratingtitle,ratingcolor',"$totalPoints between minpoints and maxpoints");
	if($customerData[0]->customerflaged == 1)
	{
		$flaged			=	"Yes";
	}
	else
	{
		$flaged			= "No";
	}
    
	$licenceValid = LicenceValid($customerData[0]->licence, $customerData[0]->customerdob);
	
	//var_dump($storeid);
	//die;
/*	$storequery			= "SELECT * FROM tblstore
					WHERE pkstoreid='2' ";				
	$distres = $db_obj->Query($storequery,true);
	var_dump($distres);
	die;*/
	
	$enda = "1702 Eglinton Avenue West, Toronto, ON M6E 2H5";
	$starta = $custAddress; 
	$testdistance = GetDistanceDetails($starta,$enda);
	
// Build left column content  $json['leftcontent']
	$leftcontent='<div class="verification-detail-line">
                            <div class="ref-img-out">
                            	<div class="ref-img"><img src="images/v-img-1.png" alt="" title=""/></div>
                            </div>
                            <div class="text">
                            	<a href="javascript:void(0);">Identification Scan Result</a> <br />
                                '.$customerData[0]->qcuniqueid.'
                            </div>
                            <div class="tick-btn-out">';
							
							if(empty($customerData[0]->qcuniqueid))
							{
								$atRisk++;
									$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  			}
					  			else
					 			 {
						 			 $passed++;
						  			 $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  			}
                            	
                           $leftcontent .='</div>
                    	</div>
						<div class="verification-detail-line">
						  <div class="ref-img-out">
							<div class="ref-img"><img src="images/v-img-2.png" alt="" title=""/></div>
						  </div>
						  <div class="text"> <a href="javascript:void(0)">Name</a> <br />
							'.ucwords($customerData[0]->customerfirstname).' '.ucwords($customerData[0]->customerlastname).' </div>
						  <div class="tick-btn-out">';
						  if(empty($customerData[0]->customerfirstname) && empty($customerData[0]->customerlastname))
						  {
								$atRisk++;
									$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  			}
					  			else
					 			 {
						 			 $passed++;
						  			 $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  			}
						  $leftcontent	.=' </div>
						</div>
						<div class="verification-detail-line">
						  <div class="ref-img-out">
							<div class="ref-img"><img src="images/v-img-2.png" alt="" title=""/></div>
						  </div>
						  <div class="text"> <a href="javascript:void(0)">Known Aliases</a> <br />
						  '.ucwords($customerData[0]->customeralias).'</div>
						  <div class="tick-btn-out">
							<div class="tick-btn">';
							if(empty($customerData[0]->customeralias))
							{
								$atRisk++;
									$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  			}
					  			else
					 			 {
						 			 $passed++;
						  			 $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  			}
							$leftcontent .='</div>
						</div></div>

						<div class="verification-detail-line">
						  <div class="ref-img-out">
							<div class="ref-img"><img src="images/v-img-3.png" alt="" title=""/></div>
						  </div>
						  <div class="text"> <a href="javascript:void(0);">Date of Birth</a> <br />
						   '.$dob.'</div>
						  <div class="tick-btn-out">
							<div class="tick-btn">';
							if(empty($dob))
							{
								$atRisk++;
									$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  			}
					  			else
					 			 {
						 			 $passed++;
						  			 $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  			}
							$leftcontent .='</div>
						  </div>
						</div>

						<div class="verification-detail-line">
						  <div class="ref-img-out">
							<div class="ref-img"><img src="images/v-img-1.png" alt="" title=""/></div>
						  </div>
						  <div class="text"> <a href="javascript:void(0);">Drivers License</a> <br />
						   '.Licenceformat($customerData[0]->licence).'</div>
						  <div class="tick-btn-out">
							<div class="tick-btn">';
								if(!$licenceValid)
								{
									$booldonotlend = true;
									$flagged++;
									$totalPoints1 = $totalPoints1 - 50;
									$leftcontent .='<p class=\'nscText\' style=\'top:0px;\'>-50</p>';
					  			}
					  			else
					 			 {
						 			 $passed++;
						  			 $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  			}
							$leftcontent .='</div>
						  </div>
						</div>

						<div class="verification-detail-line">
						  <div class="ref-img-out">
							<div class="ref-img"><img src="images/v-img-1.png" alt="" title=""/></div>
						  </div>
						  <div class="text"> <a href="javascript:void(0);">Social Insurance Number</a> <br />
						   '.SINformat($customerData[0]->socialinsurance).'</div>
						  <div class="tick-btn-out">
							<div class="tick-btn">';
								if(empty($customerData[0]->socialinsurance))
								{
									$atRisk++;
									$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  			}
					  			else
					 			 {
						 			 $passed++;
						  			 $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  			}
							$leftcontent .='</div>
						  </div>
						</div>

					<div class="verification-detail-line">
					  <div class="ref-img-out">
						<div class="ref-img"><img src="images/v-img-4.png" alt="" title=""/></div>
					  </div>
					  <div class="text"> <a href="javascript:void(0)">Current Address</a> <br />
					   '.$custAddress.'</div>
					  <div class="tick-btn-out">
						<div class="tick-btn">';
						if(empty($customerData[0]->currentaddress))
						{
							$atRisk++;
							$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
						  }
						  else
						  {
							  $passed++;
							  $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
						  }
						$leftcontent .='</div>
					</div></div>
					
					<div class="verification-detail-line">
					  <div class="ref-img-out">
						<div class="ref-img"><img src="images/v-img-5.png" alt="" title=""/></div>
					  </div>
					  <div class="text"> <a href="javascript:void(0)">Phone Number</a> <br />
						'.Phoneformat($customerData[0]->customerphone).'</div>
					  <div class="tick-btn-out">
						<div class="tick-btn">';
						if(empty($customerData[0]->customerphone))
						{
							$atRisk++;
							$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
						  }
						  else
						  {
							  $passed++;
							  $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
						  }
						$leftcontent .='</div>
					  </div>
					</div>
				<div class="verification-detail-line">
				  <div class="ref-img-out">
					<div class="ref-img"><img src="images/v-img-5.png" alt="" title=""/></div>
				  </div>
				  <div class="text"> <a href="javascript:void(0)">Mobile Phone Number</a> <br />
					'.Phoneformat($customerData[0]->customermobile).'</div>
				  <div class="tick-btn-out">
					<div class="tick-btn">';
					if(empty($customerData[0]->customermobile))
					{
						$atRisk++;
						$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  }
					  else
					  {
						  $passed++;
						  $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  }
					$leftcontent .='</div>
				  </div>
				</div>
				<div class="verification-detail-line">
				  <div class="ref-img-out">
					<div class="ref-img"><img src="images/v-img-6.png" alt="" title=""/></div>
				  </div>
				  <div class="text"> <a href="javascript:void(0)">Email Address</a> <br />
				  '.$customerData[0]->customeremail.'</div>
				  <div class="tick-btn-out">
					<div class="tick-btn">';
					if(empty($customerData[0]->customeremail))
					{
						$atRisk++;
						$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  }
					  else
					  {
						  $passed++;
						  $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  }
					$leftcontent .='</div>
				  </div>
				</div>
				<div class="verification-detail-line">
				  <div class="ref-img-out">
					<div class="ref-img"><img src="images/v-img-7.png" alt="" title=""/></div>
				  </div>
				  <div class="text"> <a href="javascript:void(0)">Current Employer</a> <br />
					'.$customerData[0]->currentemployer.'</div>
				  <div class="tick-btn-out">
					<div class="tick-btn">';
					if(empty($customerData[0]->currentemployer))
					{
						$atRisk++;
						$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  }
					  else
					  {
						  $passed++;
						  $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  }
					$leftcontent .='</div>
				  </div>
				</div>
				<div class="verification-detail-line">
					<div class="ref-img-out">
						<div class="ref-img"><img src="images/v-img-8.png" alt="" title=""/></div>
					</div>
					<div class="text">
						<a href="javascript:void(0);">Distance (km)</a> <br />
								   '.$testdistance./*.number_format($distanceKm,2).*/'
					</div>
					<div class="tick-btn-out">
					<div class="tick-btn">';
//	$swdistance = (object)array('weight' => 2, 'limit' => 10, 'safe' => 5);

					if($testdistance > $swdistance->safe)
					{
						if ($testdistance > $swdistance->limit)
						{
							$booldonotlend = true;
							$flagged++;
							$totalPoints1 = $totalPoints1 - 50;
						}
						else 
						{
							$tmpdist = ($testdistance - $swdistance->safe) * $swdistance->weight;
							$totalPoints1 = $totalPoints1 - $tmpdist;
							$atRisk++;
						}

						$leftcontent .='<p class=\'nscText\' style=\'top:0px;\'>-50</p>';
					}
					else
					{
				 	    $passed++;
				        $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					}
					$leftcontent .='</div>
				  </div>
				</div>
				<div class="verification-detail-line">
				  <div class="ref-img-out">
					<div class="ref-img"><img src="images/v-img-9.png" alt="" title=""/></div>
				  </div>
				  <div class="text"> <a href="javascript:void(0)">Outstanding (Current) Loans</a> <br />
				   '.$customerData[0]->outstandingcurrentloan.'</div>
				  <div class="tick-btn-out">
					<div class="tick-btn">';
					if(empty($customerData[0]->outstandingcurrentloan))
					{
						$atRisk++;
						$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					  }
					  else
					  {
						  $passed++;
						  $leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
					  }
					$leftcontent .='</div>
				  </div>
				</div>

				<div class="verification-detail-line">
				  <div class="ref-img-out">
					<div class="ref-img"><img src="images/v-img-10.png" alt="" title=""/></div>
				  </div>
				  <div class="text"> <a href="javascript:void(0)">Enquiries</a> <br />
				   '.$totalinquired.'</div>
				  <div class="tick-btn-out">
					<div class="tick-btn">';
//$swenquiries = (object)array('weight' => 2, 'limit' => -1, 'safe' => 3, 'time' => 48);
					if($totalinquired > $swenquiries->safe)
					{		
						
						$atRisk++;
						$leftcontent .='<img src="images/icon_no.png" alt="" title=""/>';
					 }
					 else
					 {
					    $passed++;
				    	$leftcontent .='<img src="images/tick-img.png" alt="" title=""/>';
				     }
					$leftcontent .='</div>
				  </div>
				</div>';
				
				//Build right column content
				
				//
				//GetPhoto
				//
				$photopath = "images/userphoto/";
				$photofil = "";
				$uploadstyle = "";
				if (file_exists($photopath.$cuniqueid.".jpg"))
					$photopath .= $cuniqueid.".jpg";
				else
				{
					$photopath .= "nophoto.png";
					$photofil = "";
					$uploadstyle = "style='display: none;'";
				}
				
				
				$rightcontent=' 
				<form action="" method="post" enctype="multipart/form-data" name="photoForm">
				<input type="hidden" name="uid" id="uid" value="'.$cuniqueid.'" />
					<div class="fileinputs">
						<input type="file" class="file" id="uploadphoto" name="uploadphoto" onchange="send_photo()"><br>
						
						<div class="verification-score-photo">
							<img src="'.$photopath.'" style="width:120px;height:150px;" alt="" title="" '.$photofil.'/>
						</div>
						<input type="submit" value="submit">
					</div>
				</form>
				
				
				<div class="verification-score-text">
										
											Score Card<br />
											<span>'.date('l, F d, Y',$customerData[0]->customercreated).'</span>
										</div>
										<div class="verification-stemp"><img src="images/stamp.png" alt="" title=""/></div>
										<div class="verification-hr"> </div>
										
										<div class="oneline">
											<div class="verification-btn-line">
												<div class="gree2-btn">New Loan</div>
											</div>
										</div>
										
										<div class="verification-hr"> </div>
										<div class="verification-thomas">
											'.ucwords($customerData[0]->customerfirstname).' '.ucwords($customerData[0]->customerlastname).' <br />
											<span>';
				if(!empty($dob))
				{
					$rightcontent	.='DOB '.$dob.' <br />';
				}
				if(!empty($customerData[0]->currentaddress))
				{
					 $rightcontent		.=	nl2br($customerData[0]->currentaddress).'<br />';
				}
				if(!empty($customerData[0]->customermobile))
				{
					 $rightcontent		.=	$customerData[0]->customermobile.'<br />';
				}
				if(!empty($customerData[0]->customeremail))
				{
					 $rightcontent		.=	$customerData[0]->customeremail;
				}
				
				$btncolor = "";
				if($totalunpaidloans > 0){
      			  $btncolor = "red-btn"; 
				} else {
      			 $btncolor = "red-btn\" style=\"background:#0dff00\"";
				}

			 $rightcontent		.='</span>
									</div>
									<div class="verification-hr"> </div>
								   
									<div class="oneline">
										<div class="verification-btn-line">
											<div class="verification-btn-text">Outstanding Amount</div>
											<div class="red-btn">$'.money_format("%i",$totalLoanAmount).'</div>
										</div>
										<div class="verification-btn-line">
											<div class="verification-btn-text">Loans / Unpaid</div>
											<div class="'.$btncolor.'" >'.$totalloans.' / '.$totalunpaidloans.'</div>
										</div>
										
										<div class="verification-btn-line">
											<div class="verification-btn-text">Record(s)</div>
											<div class="yellow-btn"><a href="javascript:void()" onclick=\'$("#tablehistory").show();\'>'.$historyRecords.'</a></div>
										</div>
										
										<div class="verification-btn-line">
											<div class="verification-btn-text">Risk Level</div>
											<div class="red-btn" style="background:'.$riskLevelData[0]->ratingcolor.'">'.ucwords($riskLevelData[0]->ratingtitle).'</div>
										</div>
										<div class="verification-btn-line">
											<div class="gree2-btn">SCORE</div>
											<div class="verification-btn-percent">'.$totalPoints1.'</div>
										</div>
									</div>
								</div>';
					$json['leftcontent'] = $leftcontent;
					$json['rightcontent'] = $rightcontent;
					 $json['flagged']		=	$flagged;
					 $json['passed']		=	$passed;
					 $json['atRisk']		=	$atRisk;
					 $json['tablehistory']		=	$customerHistoryTable;
					 $json['doctype']		=	$searchValue['doctype'];
					
					echo json_encode($json);
					exit;
			}
			else
			{
			$json				=	array("leftcontent"=>'
														<div class="verification-detail-line">
													  		<div class="ref-img-out">
															<div class="ref-img">&nbsp;</div>
													  	</div>
													 	 <div class="text"> <span style="text-align:center; color:#FF0000; font-size:12px; font-weight:bold;">No Result found </span></div>
													  <div class="tick-btn-out">
														<div class="tick-btn">&nbsp;</div>
													  </div>
													</div>',
											"rightcontent"	=>	'',
											'flagged'		=>	'',
					 						'passed'		=>	'',
					 						'atRisk'		=>	'');
											
						$rightcontent = "<div style='text-align:left;padding-left:10px;'>
						<div style='color:red;'>Any result found with this number<br> Please enter other document number.</div>
                   		<b><br>Search by:</b><br>
                   		<div style='padding-left:30px;'>SIN number<br>Driver licence<br>
                   			Passport number<br>
                   			Birth date (dd-mm-yyyy)<br>
                   			First or Last name (no space)
                   			</div>
                   			</div>";					
											
				 		$json['rightcontent'] = $rightcontent;
					 	$json['doctype']		=	$searchValue['doctype'];
						
			echo json_encode($json);
					exit;
			
			}
?>