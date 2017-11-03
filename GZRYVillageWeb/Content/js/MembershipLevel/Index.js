/// <reference path="../ajax.js" />
/// <reference path="../../lib/js/alert.js" />
var NotEditAlert;
var PassWordAlert;
var ErrorAlert;
var SuccessAlert;
//修改会员等级
function modify(MembershipLevelId) {
    jQuery.axpost("MemberShipLevelAjax/Get_MembershipLevel_ById", "MembershipLevelId:'" + MembershipLevelId + "'", function (data) {
        className = $(this).attr('class');
        $('#dialogBg').fadeIn(500);
        $('#dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();
        SetValue('table #LevelName', data.Model1.LevelName);
        SetValue('.box #LevelMin', data.Model1.LevelMin);
        SetValue('table #LevelMax', data.Model1.LevelMax);
        //SetValue('table #NeedThing', data.Model1.NeedThing); 
        $('table #Modify_MemberShipLevel').attr('onclick', 'modifyLevelInfo(' + data.Model1.MembershipLevelId + ')');
        return;
    }, ErrorAlert);
}

function modifyLevelInfo(MembershipLevelId) {
    var LevelName = $('table #LevelName').val();
    var LevelMin = $('.box #LevelMin').val();
    var LevelMax = $('table #LevelMax').val();
    //var NextLevelId = $('table #NextLevelId').val();
    //var NeedThing = $('table #NeedThing').val();
    if (Compare('table #LevelName')  && Compare('table #LevelMax')  && Compare('table #NeedThing')) {
        if (NotEditAlert) {
            NotEditAlert.show();
        }
        else {
            NotEditAlert = jqueryAlert({
                'content': '并未修改任何信息',
                'closeTime': 2000,
            });
            }
            return;
        }
    jQuery.axpost("MemberShipLevelAjax/Update_MembershipLevel", "MembershipLevelId:'" + MembershipLevelId +
                                              "',LevelName:'" + LevelName +
                                              "',LevelMin:'"+LevelMin+
                                              "',LevelMax:'" + LevelMax +
                                              "'"
            , function (data) {
                if (SuccessAlert) {
                    SuccessAlert.show();
                }
                else {
                    SuccessAlert = jqueryAlert({
                        'content': '修改会员等级信息成功',
                        'closeTime': 2000,
                    });
                }
                CloseDialog();
                //调用 search 的点击事件的两种方法
                $("#search").trigger("click");
                return;
            }, ErrorAlert);
}
function CloseDialog() {
    $('#dialogBg').fadeOut(300, function () {
        $('#dialog').addClass('bounceOutUp').fadeOut();
    });
}

function SetValue(str, value) {
    $(str).val(value);
    $(str + '_Hidden').val(value);
}

function Compare(str) {
    var BeforStr = $(str + '_Hidden').val();
    var AfterStr = $(str).val();
    if (BeforStr == AfterStr) {
        return true;
    }
    else {
        return false;
    }
}
