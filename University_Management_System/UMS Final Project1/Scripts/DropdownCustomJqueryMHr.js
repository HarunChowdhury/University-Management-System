

$(document).ready(function () {


    var s1 = new Array();

    var selectHtml = $('#TeacherId').text();

    s1 = $.makeArray(selectHtml);

    var s2 = $('#TeacherId option').toArray();


    var tagOption = [];
    var tagOptionattr = [];
    $('#CourseId option').each(function (index, element) {
        tagOptionattr.push($(this).attr('value'));
        tagOption.push(element);
    });

    //alert(tagOptionattr);


    //for teacher
    var tagOption1 = [];
    var tagOptionattr1 = [];
    $('#TeacherId option').each(function (index, element) {
        tagOptionattr1.push($(this).attr('value'));
        tagOption1.push(element);
    });


    //decoration


    //===============


    $(".drop-downTechId").on('change', function () {

        var a = $('option:selected', $(this)).text();;
        //alert(a);

        $.ajax({
            url: '@Url.Action("GetDropDownListSelectedData", "TeacherAssignment")?id=' + a,
            type: 'GET',

            success: function (result) {
                $('#CreditToBeTaken').val(result.t2);
                $('#RemainingCredit').val(result.t1);
                //  alert("here we" + result + "and" + $('#RemainingCredit').val());

            }
        });


        var bb = $('option:selected', $(this)).text();
        $.ajax({
            url: '@Url.Action("GetDropDownListSelectedData4", "TeacherAssignment")?id=' + a,
            type: 'GET',

            success: function (result) {
                //alert("here we" + result +"|||");


                $('#CourseId').val("");
                $('#CourseId').text("");

                var i = 0;
                var optionhtml = '<option value="' + i + '"></option>';
                $("#CourseId").append(optionhtml);


                $.each(tagOption, function (ind3, res2) {

                    var aa = true;

                    $.each(result, function (ind4, res) {
                        //alert(res +"==="+res2.textContent);




                        if (res == res2.textContent) {

                            //  alert(tagOptionattr[ind3]+" wow "+ res);

                            var optionhtml = '<option value="' + tagOptionattr[ind3] + '">' + res + '</option>';

                            $("#CourseId").append(optionhtml)

                        }
                        //else
                        //    if (aa == true) {
                        //        //aa = false;
                        //        //alert("u"+res);
                        //        //var optionhtml = '<option value="' + (ind3+1) + '">' + '</option>';

                        //        //$("#TeacherId").append(optionhtml)
                        //    }
                    });






                });
            }
        });

        //add list to course ID

        $("#Name").val("");
        $("#Credit").val("");

        // alert("askdjfl");
    });


    $(".drop-downCourseId").on('change', function () {




        var a = $('option:selected', $(this)).text();;
        //alert(a);

        $.ajax({
            url: '@Url.Action("GetDropDownListSelectedData3", "TeacherAssignment")?id=' + a,
            type: 'GET',


            success: function (result) {
                $('#Name').val(result.t3);
                $('#Credit').val(result.t1);
                //  alert("here we" + result + "and" + $('#RemainingCredit').val());

                var creditVal = parseInt(result.t1);
                var Remaining = parseInt($("#RemainingCredit").val());

                //            alert(creditVal + "  " + Remaining);


                if (creditVal > Remaining) {
                    alert("Not enough Credit is Left");
                }
            }
        });
        // alert("askdjfl");

        //validation part.
        //maximum credit value



    });

    $(".drop-downDptId").on('change', function () {


        var a = $('option:selected', $(this)).text();;
        //alert("asdfa");

        $.ajax({
            url: '@Url.Action("GetDropDownListSelectedData2", "TeacherAssignment")?id=' + a,
            type: 'GET',
            datatype: "json",


            success: function (result) {
                //alert("asdfa "+result);


                $('#TeacherId').val("");
                $('#TeacherId').text("");




                //$.each(selectHtml, function () {

                //alert("here");


                var i = 0;
                var optionhtml = '<option value="' + i + '"></option>';


                $("#TeacherId").append(optionhtml);


                $.each(tagOption1, function (ind3, res2) {

                    var aa = true;

                    $.each(result, function (ind4, res) {
                        //alert(res +"==="+res2.textContent);




                        if (res == res2.textContent) {

                            // alert(tagOptionattr1[ind3] + " wow " + res);

                            var optionhtml = '<option value="' + tagOptionattr1[ind3] + '">' + res + '</option>';

                            $("#TeacherId").append(optionhtml)

                        }

                    });






                });

                //$.each(s2, function (ind2, res2) {

                //var aa = true;

                //$.each(result, function (ind, res) {
                // //   alert(res2.text);
                //    if (res == res2.text) {

                //        var optionhtml = '<option value="' + (ind2+1) + '">' + res + '</option>';

                //        $("#TeacherId").append(optionhtml)

                //    }
                //    else
                //    if (aa == true) {
                //            //aa = false;
                //            //alert("u"+res);
                //            //var optionhtml = '<option value="' + (ind2+1) + '">' + '</option>';

                //            //$("#TeacherId").append(optionhtml)
                //        }
                //});






                //});




                //$('#Credit').val(result.t1);
                //  alert("here we" + result + "and" + $('#RemainingCredit').val());

            }
        });
        // alert("askdjfl");
    });

})
