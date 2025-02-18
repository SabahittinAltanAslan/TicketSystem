$(document).ready(function () {
    let token = localStorage.getItem("token");
    if (!token) {
        alert("Lütfen giriş yapınız.");
        window.location.href = "index.html";
        return;
    }

    function loadDataTable() {
        if (typeof $.fn.DataTable === "undefined") {
            setTimeout(loadDataTable, 1000);
            return;
        }

        $("#ticketsTable").DataTable({
            ajax: {
                url: "/api/ticket/it-tickets",
                type: "GET",
                headers: { "Authorization": `Bearer ${token}` },
                dataSrc: ""
            },
            columns: [
                { data: "id" },
                { data: "title" },
                { data: "description" },
                { data: "status" },
                {
                    data: "createdAt",
                    render: function (data) {
                        return new Date(data).toLocaleDateString();
                    }
                },
                {
                    data: "id",
                    render: function (data) {
                        return `<button class="btn btn-primary btn-sm" onclick="viewTicket(${data})">Detay</button>`;
                    }
                }
            ]
        });
    }

    loadDataTable();
});

function viewTicket(ticketId) {
    window.location.href = `ticket-detail.html?id=${ticketId}`;
}
