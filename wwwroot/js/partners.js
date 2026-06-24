$(function () {
    $(document).on("click", ".partner-row", function () {
        const partnerID = $(this).attr("partnerID");

        $.get(`/Partners/PartnerDetails/${partnerID}`, function (html) {
            $("#partnerDetailsContent").html(html);
            $("#partnerDetailsModal").modal("show");
        });
    });

    $(document).on("click", "#partnerDetailsModal .close", function () {
        $("#partnerDetailsModal").modal("hide");
    });

    $(document).on("click", ".add-policy-btn", function (e) {
        e.stopPropagation();

        const partnerID = $(this).data("partner-id");
        const partnerName = $(this).data("partner-name");

        $("#policyPartnerID").val(partnerID);
        $("#policyPartnerName").text(partnerName);

        $("#addPolicyModal").modal("show");
    });

    $(document).on("click", "#addPolicyModal .close", function () {
        $("#addPolicyModal").modal("hide");
    });

    $("#partnerSearch").on("input", function () {
        const searchValue = $(this).val().toLowerCase();

        $(".partner-row").each(function () {
            const rowText = $(this).text().toLowerCase();

            if (rowText.includes(searchValue)) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    });
});