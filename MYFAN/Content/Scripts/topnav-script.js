
var ww = document.body.clientWidth;

$(document).ready(function() {
	
	$(".mnav li a").each(function() {
		if ($(this).next().length > 0) {
			$(this).addClass("parent")
			$(this).parent().append('<span class="arrow"></span>');
		};
	})
	
	
	$(".main-menu").find('.toggleMenu').click(function(e) {
		e.preventDefault();
		$(this).toggleClass("active");
		$(".main-menu").find(".mnav").slideToggle();
	});
	
	$(".main-menu1").find('.toggleMenu').click(function(e) {
		e.preventDefault();
		$(this).toggleClass("active");
		$(".main-menu1").find(".mnav").toggle();
	});	
	adjustMenu();
})

$(window).bind('resize orientationchange', function() {
	ww = document.body.clientWidth;
	adjustMenu();
});

var adjustMenu = function() {
	if (ww < 982) {
		$(".toggleMenu").css("display", "inline-block");
		if (!$(".toggleMenu").hasClass("active")) {
			$(".mnav").hide();
		} else {
			$(".mnav").show();
		}
		$(".mnav li").unbind('mouseenter mouseleave');
		$(".mnav li span").unbind('click').bind('click', function(e) {
			// must be attached to anchor element to prevent bubbling
			e.preventDefault();
			$(this).parent("li").toggleClass("hover");
		});
	} 
	else if (ww >= 982) {
		$(".toggleMenu").css("display", "none");
		$(".mnav").show();
		$(".mnav li").removeClass("hover");
		$(".mnav li a").unbind('click');
		$(".mnav li").unbind('mouseenter mouseleave').bind('mouseenter mouseleave', function() {
		 	// must be attached to li so that mouseleave is not triggered when hover over submenu
		 	$(this).toggleClass('hover');
		});
	}
}

