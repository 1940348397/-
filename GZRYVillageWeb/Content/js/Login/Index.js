/// <reference path="../ajax.js" />
/// <reference path="../../lib/js/alert.js" />
var UserNameAlert;
var PassWordAlert;
var ErrorAlert;
var SuccessAlert;
function LoginOn() {
    var UserName = $("#UserName").val();
    if (UserName == "") {
        if (UserNameAlert) {
            return UserNameAlert.show();
        }
        UserNameAlert = jqueryAlert({
            'content': '请输入用户名',
            'closeTime': 2000,
        });
        return;
    }
    var PassWord = $("#PassWord").val();
    if (PassWord == "") {
        if (PassWordAlert) {
            return PassWordAlert.show();
        }
        PassWordAlert = jqueryAlert({
            'content': '请输入密码',
            'closeTime': 2000,
        });
        return;
    }

    jQuery.axpost("LoginAjax/LoginIn", "UserName:'" + UserName + "',PassWord:'" + PassWord + "'", function (data) {
        if (SuccessAlert) {
            return SuccessAlert.show();
        }
        SuccessAlert = jqueryAlert({
            'content': '登入成功',
            'modal': true,
            'buttons': {
                '确定': function () {
                    SuccessAlert.close();
                    window.location.href = "../Login/Login";
                }
            }
        })
    }, ErrorAlert);
}