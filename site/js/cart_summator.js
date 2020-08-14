function add(n)
{
	var result = 1;
	if(result == 'NaN' || result == '') result = 0;	 
	result *= parseFloat(document.getElementById("price_"+n).value);
	result *= parseFloat(document.getElementById("count_"+n).value);
	document.getElementById("result_"+n).innerHTML = result;
	
	var total=document.getElementById("total");
	total.innerHTML=Number(total.innerHTML)+Number((document.getElementById("price_"+n).value) * (document.getElementById("count_"+n).value));
}