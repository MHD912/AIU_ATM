$(document).ready(function () {

    // Stick the navigation bar to the window at all times
    $(window).scroll(function () {
        if (this.scrollY > 70) {
            $('.navbar').addClass("sticky");
        }
        else {
            $('.navbar').removeClass("sticky");
        }

        if (this.scrollY > 500) {
            $('.scroll-up-btn').addClass("show");
        }
        else {
            $('.scroll-up-btn').removeClass("show");
        }
    });

    // Slide-up script
    $('.scroll-up-btn').click(function () {
        $('html').animate({ scrollTop: 0 }, 0);
    });

    // Toggle menu/navbar script
    $('.menu-btn').click(function () {
        $('body').toggleClass("menu-open");
        $('.home').toggleClass("menu-open");
        $('.menu').toggleClass("menu-open");
        $('.navbar .menu').toggleClass("active");
        $('.menu-hamburger').toggleClass("active");
    });
    
});