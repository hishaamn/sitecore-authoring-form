(function (speak) {
    speak.pageCode(["sitecore", "jquery"],
        function (sitecore, $) {
            return {
                initialize: function () {
                    this.getItemList();
                },
                getItemList: function () {
                    var app = this;

                    // app.ProgressIndicator.set("isBusy", true);
                    // app.ProgressIndicator.set("IsVisible", true);

                    $.ajax({
                        type: "GET",
                        dataType: "json",
                        url: "/api/sitecore/AuthoringForm/SiteCreator",
                        cache: false,
                        success: function (data) {
                            app.FormList.DynamicData = data;
                        },
                        error: function () {
                            console.log("There was an error. Try again please!");
                        },
                        complete: function () {
                            // app.ProgressIndicator.set("isBusy", false);
                            // app.ProgressIndicator.set("IsVisible", false);
                        }
                    });
                }
            };
        });
})(Sitecore.Speak);