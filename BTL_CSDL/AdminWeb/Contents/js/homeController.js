$(document).ready(function () {
    
    $(".ajax_editRow").click(function (e) {
        e.preventDefault();
        var nameTable = $(".ajax_selected_click option:selected").text();
        var key1 = $(this).closest("tr").find(".key1").text();
        var key2 = $(this).closest("tr").find(".key2").text();
        var key3 = $(this).closest("tr").find(".key3").text();
        //var $row = $(this).parent().parent();
        //var $row = $(this).closest("tr");
        //var $tds = $row.find("td");
        //var rowval = ""
        //$.each($tds, function () {
        //    rowval = rowval+($(this).text());
        //});
        var dataModel = $('#myModal');
        $.ajax({
            url: '/Home/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: key1, key2: key2, key3: key3, actionName: "ModifyRow" },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
        });

    });

    $(".ajax_deleteRow").click(function (e) {
        e.preventDefault();
        var dataModel = $('#myModal');
        var nameTable = $(".ajax_selected_click option:selected").text();
        var key1 = $(this).closest("tr").find(".key1").text();
        var key2 = $(this).closest("tr").find(".key2").text();
        var key3 = $(this).closest("tr").find(".key3").text();
        $.ajax({
            url: '/Home/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: key1, key2: key2, key3: key3, actionName: 'DeleteRow' },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
        });
    });

    $(".ajax_add_item").click(function (e) {
        e.preventDefault();
        var nameTable = $(".ajax_selected_click option:selected").text();
        var dataModel = $('#myModal');
        $.ajax({
            url: '/Home/ShowRow',
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTable, key1: null, key2: null, key3: null, actionName: 'AddRow' },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); dataModel.modal(); }
        });
    });

    $(".ajax_selected_click").change(function (e) {
        e.preventDefault();
        var nameTb = $(".ajax_selected_click option:selected").text();
        var dataModel = $('#dataTable');
        $.ajax({
            url: '/Home/getTableData/' + nameTb,
            contentType: 'application/html ; charset:utf-8',
            data: { tableName: nameTb },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); }
        });
    });

    $(".ajax_btn_submit").click(function (e) {
        e.preventDefault();
        var actionName = $(".ajax_btn_submit").val();
        var nameTb = $(".ajax_selected_click option:selected").text();
        var dataModel = $('#dataTable');
        var dataModal = $('#myModal');
        var formdata = new FormData();
        var count = 0;
        var tableName = $('.fied_tableName').val();
        formdata.append("TableName", tableName);
        $('.input_vaule').each(function () {
            formdata.append(count.toString(), $(this).val());
            count++;
        });
        var count = 50;
        $('.input_dataO').each(function () {
            formdata.append(count.toString(), $(this).val());
            count++;
        });
        if (actionName == "Add") {
            $.ajax({
                url: '/Home/AddRow/' + nameTb,
                contentType: 'application/html ; charset:utf-8',
                contentType: false,
                processData: false, // Not to process data
                data: formdata,
                async: false,
                type: 'POST',
                dataType: 'html',
                success: function (result) { dataModel.empty().append(result); dataModal.modal('hide'); }
            });
        }
        else {
            if (actionName == "Save change") {
                $.ajax({
                    url: '/Home/ModifyRow/' + nameTb,
                    contentType: 'application/html ; charset:utf-8',
                    contentType: false,
                    processData: false, // Not to process data
                    data: formdata,
                    async: false,
                    type: 'POST',
                    dataType: 'html',
                    success: function (result) { dataModel.empty().append(result); dataModal.modal('hide'); }
                });
            }
            else {
                $.ajax({
                    url: '/Home/DeleteRow/' + nameTb,
                    contentType: 'application/html ; charset:utf-8',
                    contentType: false,
                    processData: false, // Not to process data
                    data: formdata,
                    async: false,
                    type: 'POST',
                    dataType: 'html',
                    success: function (result) { dataModel.empty().append(result); dataModal.modal('hide'); }
                });
            }
        }

    });

    $(".ajax_FindingStudent").click(function (e) {
        e.preventDefault();
        var check1 = $(".MSV").is(':checked').toString();
        var check2 = $(".NSV").is(':checked').toString();
        var key = $(".find_feid").val();
        var dataModel = $('#ajax_tableRE');
        $.ajax({
            url: '/Home/FindingStudentAjax/' + key,
            contentType: 'application/html ; charset:utf-8',
            data: { key: key, check1: check1, check2: check2 },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); }
        });

    });

    $(".ajax_FindingTKT").unbind().click(function (e) {
        e.preventDefault();
        var check1 = $(".MSV").is(':checked').toString();
        var check2 = $(".NSV").is(':checked').toString();
        var key = $(".find_feid").val();
        var dataModel = $('#ajax_tableTKT');
        $('.SV_TKT').hide();
        $.ajax({
            url: '/Home/FindingTKTAjax/' + key,
            contentType: 'application/html ; charset:utf-8',
            data: { keyTKT: key},
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); }
        });
    });

    $("#tableTKT tbody tr").on("click", function (e) {
        e.preventDefault();
        var key = $(this).closest("tr").find(".keyTKT").text();
        key=key.trim();
        var dataModel = $('#ajax_tableRETKT');
        $('.SV_TKT').show();
        $.ajax({
            url: '/Home/FindingTKTAllSVAjax/'+key,
            contentType: 'application/html ; charset:utf-8',
            data: { keyTKT: key },
            type: 'GET',
            dataType: 'html',
            success: function (result) { dataModel.empty().append(result); }
        });
    });
    
});
//$('#myModal').modal({
//    remote: url,
//    refresh: false
//});