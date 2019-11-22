(function (a) {
    var b = a("#header-sticky");
    var e = a(window);
    e.on("scroll", function () {
        if (a(this).scrollTop() > 120) {
            b.addClass("sticky")
        } else {
            b.removeClass("sticky")
        }
    });
    jQuery("#mobile-menu-active").meanmenu();
    new WOW().init();
    a(".slider-active").owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        autoplay: false,
        nav: true,
        dots: true,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
    a(".quickview-active").owlCarousel({
        loop: true,
        autoplay: false,
        autoplayTimeout: 5000,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        nav: true,
        item: 3,
        margin: 12,
    });
    var c = a(".product-details-small a");
    c.on("click", function (g) {
        g.preventDefault();
        var f = a(this).attr("href");
        c.removeClass("active");
        a(this).addClass("active");
        a(".product-details-large .tab-pane").removeClass("active");
        a(".product-details-large " + f).addClass("active")
    });
    a(".tab-active").owlCarousel({
        smartSpeed: 1000,
        nav: true,
        autoplay: false,
        dots: false,
        loop: true,
        margin: 20,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            480: {
                items: 2
            },
            768: {
                items: 3
            },
            992: {
                items: 4
            },
            1170: {
                items: 4
            },
            1300: {
                items: 5
            }
        }
    });
    a(".tab-active-2").owlCarousel({
        smartSpeed: 1000,
        nav: false,
        autoplay: true,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            1000: {
                items: 3
            },
            1170: {
                items: 3
            },
            1300: {
                items: 4
            }
        }
    });
    a(".tab-active-3").owlCarousel({
        smartSpeed: 1000,
        nav: true,
        autoplay: true,
        loop: true,
        margin: 20,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1170: {
                items: 3
            },
            1300: {
                items: 4
            }
        }
    });
    a(".post-active").owlCarousel({
        smartSpeed: 1000,
        nav: true,
        autoplay: false,
        dots: false,
        items: 3,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1170: {
                items: 3
            },
            1300: {
                items: 3
            }
        }
    });
    a(".bestseller-active").owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: true,
        autoplay: false,
        dots: false,
        margin: 20,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            480: {
                items: 2
            },
            768: {
                items: 2
            },
            1000: {
                items: 2
            }
        }
    });
    a(".product-active-2").owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: true,
        autoplay: false,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
    a(".product-active-3").owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: true,
        autoplay: false,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
    a(".testimonial-active").owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: false,
        autoplay: true,
        dots: true,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
    a(".deal-active").owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: false,
        autoplay: false,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
    a(".post-active-2").owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: false,
        autoplay: false,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
    a(".hot-sell-active").owlCarousel({
        smartSpeed: 1000,
        margin: 20,
        nav: true,
        autoplay: false,
        dots: false,
        items: 3,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            }
        }
    });
    a(".blog-slider-active").owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: false,
        autoplay: true,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
    a(".bg").parallax("50%", 0.1);
    a(".flexslider").flexslider({
        animation: "slide",
        controlNav: "thumbnails"
    });
    a("#showlogin").on("click", function () {
        a("#checkout-login").slideToggle(900)
    });
    a("#showcoupon").on("click", function () {
        a("#checkout_coupon").slideToggle(900)
    });
    a("#cbox").on("click", function () {
        a("#cbox_info").slideToggle(900)
    });
    a("#ship-box").on("click", function () {
        a("#ship-box-info").slideToggle(1000)
    });
    a("#showcat").on("click", function () {
        a("#hidecat").slideToggle(900)
    });
    a(".rx-parent").on("click", function () {
        a(".rx-child").slideToggle();
        a(this).toggleClass("rx-change")
    });
    a("[data-countdown]").each(function () {
        var f = a(this),
            g = a(this).data("countdown");
        f.countdown(g, function (h) {
            f.html(h.strftime('<div class="cdown days"><span class="counting counting-2">%-D</span>days</div><div class="cdown hours"><span class="counting counting-2">%-H</span>hrs</div><div class="cdown minutes"><span class="counting counting-2">%M</span>mins</div><div class="cdown seconds"><span class="counting">%S</span>secs</div>'))
        })
    });
    a(".counter").counterUp({
        delay: 10,
        time: 1000
    });
    a("#cate-toggle li.has-sub>a").on("click", function () {
        a(this).removeAttr("href");
        var f = a(this).parent("li");
        if (f.hasClass("open")) {
            f.removeClass("open");
            f.find("li").removeClass("open");
            f.find("ul").slideUp()
        } else {
            f.addClass("open");
            f.children("ul").slideDown();
            f.siblings("li").children("ul").slideUp();
            f.siblings("li").removeClass("open");
            f.siblings("li").find("li").removeClass("open");
            f.siblings("li").find("ul").slideUp()
        }
    });
    a("#cate-toggle>ul>li.has-sub>a").append('<span class="holder"></span>');
    a.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: "linear",
        scrollSpeed: 900,
        animation: "fade"
    });
    if (a(window).width() < 768) {
        function d() {
            var f = a(".category-menu");
            f.find("nav.menu .cr-dropdown").find(".left-menu").css("display", "none");
            f.find("nav.menu .cr-dropdown ul").slideUp();
            f.find("nav.menu .cr-dropdown a").on("click", function (g) {
                g.preventDefault();
                a(this).parent(".cr-dropdown").children("ul").slideToggle()
            });
            f.find("nav.menu .cr-dropdown ul .cr-sub-dropdown ul").css("display", "none");
            f.find("nav.menu .cr-dropdown ul .cr-sub-dropdown a").on("click", function (g) {
                g.preventDefault();
                a(this).parent(".cr-sub-dropdown").children("ul").slideToggle()
            })
        }
        d()
    }
})(jQuery);