// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    $(".s2createcat").select2();
    $(".sTag").select2();

    $(".s2createtag").select2();
    $(".s2cat").select2();
    tinyMCE.init({
        selector: ".create-post ",
    })




    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#editimg').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]); // convert to base64 string
        }
    }

    $("#myimg").change(function () {
        readURL(this);
    });

    $(".dropdown").hover(function () {
        var dropdownMenu = $(this).children(".dropdown-menu");
        if (dropdownMenu.is(":visible")) {
            dropdownMenu.parent().toggleClass("open");
        }
    });

    var cat = $(".cat");
    var post = $(".pt");
    var tag = $(".tg");
    if (cat || post || tag) {
        post.DataTable();
        cat.DataTable();
        tag.DataTable();
    }

    var sty = document.getElementById("progress-bar");
    if (sty) {
        let processScroll = () => {
            let docElem = document.documentElement,
                docBody = document.body,
                scrollTop = docElem['scrollTop'] || docBody['scrollTop'],
                scrollBottom = (docElem['scrollHeight'] || docBody['scrollHeight']) - window.innerHeight,
                scrollPercent = scrollTop / scrollBottom * 100 + '%';

            // console.log(scrollTop + ' / ' + scrollBottom + ' / ' + scrollPercent);

            sty.style.setProperty("--scrollAmount", scrollPercent);
        }

        document.addEventListener('scroll', processScroll)
    }

    $.ajax({
        url: "/api/comments/",
        type: 'GET',
        success: function (res) {
            $(".alert-num").text(res);
        }
    });

    $.ajax({
        url: "/api/posts/draft/count",
        type: 'GET',
        success: function (res) {
            $(".draft-num").text(res);
        }
    });

    $.ajax({
        url: "/api/posts/trash/count",
        type: 'GET',
        success: function (res) {
            $(".trash").text(res);
        }
    });

    //let uniquehits = JSON.stringify({ uniqueHits: 1 });
    //$.ajax({
    //    url: "/api/stats",
    //    type: 'POST',
    //    data: uniquehits,

    //    contentType: "application/json",
    //    success: function (res) {
    //        alert("don");
    //    }
    //});







    $.ajax({
        url: "/api/categories",
        type: 'GET',
        success: function (data) {
            for (var i = 0; i < data.length; ++i) {
                i<6 ? 
                $('#main-nav').append(
                    `
                <li class="nav-item">
                    <a class="nav-link text-dark" href="/posts/category/${data[i].slug}">
                ${data[i].name}

                    </a>

                </li>
        `):'';
            }
        
        }
    });

    //$(".dbtn").click(function (event) {
    //    var btn = $(".dbtn");
    //    var id = Number($('.dbtn').attr("data-id"));
    //    let data = JSON.stringify({ id: id });


    //    alertify.confirm("Are you sure to Delete?",
    //        function () {
    //            $.ajax({
    //                method: "DELETE",
    //                url: "/api/posts/" + id,
    //                data: data,
    //                contentType: "application/json",
    //            }).done(function () {
    //                event.target.parentElement.parentElement.remove();

    //                alertify.success('Post is Deleted!');
    //            }).fail(function (msg) {
    //                console.log('FAIL');
    //            }
    //            ).always(function (msg) {

    //            });
    //        },
    //        function () {
    //            alertify.error('Cancelled');
    //        });
    //})


    $(".dbtn").click(function (event) {
        var btn = $(".dbtn");
        var id = Number($('.dbtn').attr("data-id"));
        let data = JSON.stringify({ postStatus: 0 });


        alertify.confirm("Are you sure to Delete?",
            function () {
                $.ajax({
                    method: "POST",
                    url: "/api/posts/" + id,
                    data: data,
                    contentType: "application/json",
                }).done(function () {
                    event.target.parentElement.parentElement.remove();

                    alertify.success('Post is Deleted!');
                }).fail(function (msg) {
                    console.log('FAIL');
                }
                ).always(function (msg) {

                });
            },
            function () {
                alertify.error('Cancelled');
            });
    })
});

