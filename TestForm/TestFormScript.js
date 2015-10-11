 (function () {
 var colectionFirst = document.getElementsByClassName("first");
 var firstLan = colectionFirst.length;
window.addEventListener('resize', function (event) {
	

	if(window.innerWidth < document.getElementById("wrapper").offsetWidth) {
	
		document.body.setAttribute("id", "addScroll"); 
		for (i = 1; i < document.getElementsByClassName("first").length; i++){
				if(i % 2 == 0){
					document.getElementsByClassName("first")[i].style.background="#dddddd";
					document.getElementsByClassName("last")[i].style.background="#dddddd";
				}
				else{
					document.getElementsByClassName("first")[i].style.background="#ffffff";
					document.getElementsByClassName("last")[i].style.background="#ffffff";
				}
			} 
		
	}
	else{
		document.body.removeAttribute("id", "addScroll");
	}
	
	if(window.innerHeight < document.getElementById("wrapper").offsetHeight){
		document.getElementsByTagName("tfoot")[0].setAttribute("class", "footerFixed");	
	}
	else{
		document.getElementsByTagName("tfoot")[0].removeAttribute("class", "footerFixed");
		document.getElementsByTagName("thead")[0].removeAttribute("class", "headFixed");
			document.getElementsByClassName("first")[0].style.top = "80px";
			document.getElementsByClassName("last")[0].style.top = "80px";
			for (i = 1; i < document.getElementsByClassName("first").length; i++){
			
				document.getElementsByClassName("first")[i].style.top = (80 + ((i-1) * 60) - window.pageYOffset) + 80 + "px";
				document.getElementsByClassName("last")[i].style.top = (80 + ((i-1) * 60) - window.pageYOffset) + 80 + "px";
				} 
	}

});
window.onscroll = function (e) {
		//scroll horizontal
		var lastScrollLeft = 0;
		var documentScrollLeft = window.pageXOffset;
		if (lastScrollLeft != documentScrollLeft) {
			document.getElementsByTagName("thead")[0].removeAttribute("class", "headFixed");
			lastScrollLeft = documentScrollLeft;
			document.getElementsByClassName("first")[0].style.top = "80px";
			document.getElementsByClassName("last")[0].style.top = "80px";
			for (i = 1; i < document.getElementsByClassName("first").length; i++){
				
				document.getElementsByClassName("first")[i].style.top = (80 + ((i-1) * 60) - window.pageYOffset) + 80 + "px";
				document.getElementsByClassName("last")[i].style.top = (80 + ((i-1) * 60) - window.pageYOffset) + 80 + "px";
				} 
		}
		
		//scroll vertical
		var lastScrollTop = 0;
		var documentScrollTop = window.pageYOffset;
		if (lastScrollTop != documentScrollTop) {
			document.getElementsByTagName("thead")[0].setAttribute("class", "headFixed");
						
			lastScrollTop = documentScrollTop;
			document.getElementsByClassName("first")[0].style.top = "0px";
			document.getElementsByClassName("last")[0].style.top = "0px";
		
			for (i = 1; i < document.getElementsByClassName("first").length ; i++){
			
				document.getElementsByClassName("first")[i].style.top = (80 + ((i-1) * 60) - window.pageYOffset) + "px";
				document.getElementsByClassName("last")[i].style.top = (80 + ((i-1) * 60) - window.pageYOffset) + "px";
				
				
			} 
			
		}

		
};


}());	





