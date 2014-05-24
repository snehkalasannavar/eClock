$('.add-module').click(function (event) {
    event.preventDefault();

    $.ajax({
        url: "/Project/GetNewModuleRow",
        data: { projectId: $(this).attr('projectId') }
    }).done(function (newModuleRow) {
        $(newModuleRow).insertAfter('table tr:last-child');
        saveButtonHandler();
        deleteButtonHandler();
    });
});

var saveButtonHandler = function () {
    $('.save-module').click(function (event) {
        event.preventDefault();
        var moduleId = $(this).attr('dataModuleId');
        var moduleName = $(this).parent('td').children('input').val();
        //var moduleName = $('input[data-module-id = "' + moduleId + '"]').val();
        var moduleProjectId = $(this).attr('projectId');
        $.ajax({
            url: "/Project/SaveModule",
            type: "POST",
            data: {
                Id: moduleId,
                Name: moduleName,
                ProjectId: moduleProjectId
            }
        }).done(function (data) {
            if (moduleId == 0) {
                $('input .moduleTextBox').data('module-id', data.moduleId);
            }
        });
    });
};

var deleteButtonHandler = function () {
    $('.delete-module').click(function (event) {
        event.preventDefault();
        var delButton = $(this);
        var moduleId = $(delButton).attr('dataModuleId');
        if (moduleId == 0) {
            $(delButton).closest('tr').remove();
        }
        else {
            $.ajax({
                url: "/Project/DeleteModule",
                type: "POST",
                data: { moduleId: moduleId }
            }).done(function (deleteModule) {
                if (deleteModule.Success) {
                    $(delButton).closest('tr').remove();
                }
            });
        }
    });
};

saveButtonHandler();
deleteButtonHandler();