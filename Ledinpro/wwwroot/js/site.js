// 植物灯页面脚本.
$(document).ready(function () {
    // 菜单点击事件
    var currentClickMenu = ""
    $('#News').click(function (e) {
        e.preventDefault()
        setMenuTitleColor("News")
        $('html,body').animate({ scrollTop: $('#companyNews').offset().top - 75 }, 1000)
    });

    $('#Products').click(function (e) {
        e.preventDefault()
        setMenuTitleColor("Products")
        $('html,body').animate({ scrollTop: $('#productScenes').offset().top - 75 }, 1000)
    });

    $('#Company').click(function (e) {
        e.preventDefault()
        setMenuTitleColor("Company")
        $('html,body').animate({ scrollTop: $('#companyIntroduce').offset().top - 75 }, 1000)
    });

    $('#Contact_Us').click(function (e) {
        e.preventDefault()
        setMenuTitleColor("Contact_Us")
        $('html,body').animate({ scrollTop: $('#contact').offset().top - 75 }, 1000)
    });

    function setMenuTitleColor(menuId) {
        if (currentClickMenu != "") {
            $("#" + currentClickMenu).css("color", "#000000")
        }

        currentClickMenu = menuId
        $("#" + currentClickMenu).css("color", "#f37044")
    }

    // 点击场景滚动到对应的产品
    $('.productSceneNavigation').click(function (e) {
        e.preventDefault()
        // 字符串转换成数字类型使用Number
        var scrollId = (1000000 + Number(this.id)).toString();
        $('html,body').animate({ scrollTop: $('#' + scrollId).offset().top - 93 }, 1000);
    });

    // 留言信息ajax方法
    $("#sendMessage").click(function () {
        var model = $('#userMessage').serializeObject();

        if (model.Name.length <= 0) {
            alert("Please input name!")
            return;
        }

        if (model.Email.length <= 0) {
            alert("Please input message!")
            return;
        }

        if (model.Message.length <= 0) {
            alert("Please input message!")
            return;
        }

        $.ajax({
            type: "POST",
            url: "SaveCustomerMessage",
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(result) {
                if (result == true) {
                    // 提交成功
                    alert("Send Message Successfully!")
                } else if (result == "VerifyFailed") {
                    // 验证失败
                    alert("Verify Failed!")
                } else {
                    alert("Send Message Failed!")
                }
            }
        });
    });
})