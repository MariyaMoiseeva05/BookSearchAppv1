//работа с модалками
var modals = {
    // очистка полей модальных форм с вводом
    closeAllModals: function () {
        $('*').modal('hide');
        $("#error-msg-step").hide();
        $("#error-msg").hide();
    },
    clearFormModal: function () {
        $('*').modal('hide');
        $('input[type=\"text\"]').val("");
    },
    //вызов модалки с созданием новой мысли
    creatingFormModal: function () {
        $('#form_modal_label').html("Создание проекта");
        $('#project-actual_end_date').parent().hide();
        $('#project-completed').parent().hide();
        $('#project-deleted').parent().hide();
        $('#project-paid').parent().hide();

        $('#save-btn').attr("onclick", "project.createProject()");
    },
    // вызов модалки с обновлением информации о мысли
    updatingFormModal: function (id) {
        $('#view_modal').hide();
        $('#form_modal_label').html("Обновление информации");
        $('#create-think-title').parent().show();
        $('#create-think-content').parent().show();
        $('#create-think-date').parent().show();
        $('#project-paid').parent().show();
        think.insertDataToForm(id);
    },
    //вызов модалки с созданием нового этапа
    creatingFormModalStep: function (id) {
        $('#view_modal').hide();
        $('#form_modal_label_step').html("Создание этапа");
        $('#step-actual_end_date').parent().hide();
        $('#step-completed').parent().hide();
        $('#step-paid').parent().hide();

        $('#step-save-btn').attr("onclick", "step.createStep(" + id + ")");
    },
    // вызов модалки с обновлением информации ою этапе
    updatingFormModalStep: function (id) {
        $('#view_modal_step').hide();
        $('#form_modal_label_step').html("Обновление информации об этапе");
        $('#step-actual_end_date').parent().show();
        $('#step-completed').parent().show();
        $('#step-paid').parent().show();

        step.insertDataToForm(id);
    },
};