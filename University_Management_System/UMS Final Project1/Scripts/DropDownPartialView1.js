$(function () {
    //  alert("here");

    $("#DepartmentId1").on("change", function () {
        var id = $("#DepartmentId1").val();
        alert("asdf" + id);


        $("div #section-data").load("TeacherAssignment/FilteredViewCourseStatus", { departmentId: id });
    });
});
