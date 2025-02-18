$(document).ready(function () {
    let token = localStorage.getItem("token");
    let userRole = localStorage.getItem("role"); // Kullanıcı rolünü al
    if (!token) {
        alert("Lütfen giriş yapınız.");
        window.location.href = "index.html";
        return;
    }

    // 📌 Yalnızca ITEmployee rolündekiler "Şube Ekle" butonunu görebilir
    if (userRole === "ITEmployee") {
        $("#addBranchBtn").show();
    }

    function loadDataTable() {
        if (typeof $.fn.DataTable === "undefined") {
            setTimeout(loadDataTable, 1000);
            return;
        }

        $("#branchesTable").DataTable({
            destroy: true,
            ajax: {
                url: "http://localhost:7199/api/branch",
                type: "GET",
                headers: { "Authorization": `Bearer ${token}` },
                dataSrc: "data"
            },
            columns: [
                { data: "id" },
                { data: "name" },
                {
                    data: "id",
                    render: function (data, type, row) {
                        return `
                            <button class="btn btn-info btn-sm" onclick="viewBranch(${row.id})">Detay</button>
                            <button class="btn btn-warning btn-sm" onclick="editBranch(${row.id}, '${row.name}')">Güncelle</button>
                            <button class="btn btn-danger btn-sm" onclick="deleteBranch(${row.id})">Sil</button>
                        `;
                    }
                }
            ]
        });
    }

    loadDataTable();

    // 📌 Şube Ekleme Modalını Aç
    $("#addBranchBtn").click(function () {
        $("#branchModal").modal("show");
    });

    // 📌 Yeni Şube Ekleme İşlemi
    $("#branchForm").submit(function (e) {
        e.preventDefault();
        let branchName = $("#branchName").val();

        $.ajax({
            url: "/api/branch",
            type: "POST",
            headers: { "Authorization": `Bearer ${token}`, "Content-Type": "application/json" },
            data: JSON.stringify({ name: branchName }),
            success: function () {
                alert("Şube başarıyla eklendi!");
                $("#branchModal").modal("hide");
                $("#branchForm")[0].reset();
                $("#branchesTable").DataTable().ajax.reload();
            },
            error: function (err) {
                alert("Hata oluştu: " + err.responseText);
            }
        });
    });

    // 📌 Şube Güncelleme Modalını Aç
    $("#updateBranchForm").submit(function (e) {
        e.preventDefault();
        let branchId = $("#updateBranchId").val();
        let branchName = $("#updateBranchName").val();

        $.ajax({
            url: `/api/branch/${branchId}`,
            type: "PUT",
            headers: { "Authorization": `Bearer ${token}`, "Content-Type": "application/json" },
            data: JSON.stringify({ id: branchId, name: branchName }),
            success: function () {
                alert("Şube başarıyla güncellendi!");
                $("#updateBranchModal").modal("hide");
                $("#updateBranchForm")[0].reset();
                $("#branchesTable").DataTable().ajax.reload();
            },
            error: function (err) {
                alert("Hata oluştu: " + err.responseText);
            }
        });
    });
});

// 📌 Şube Güncelleme İşlemi
function editBranch(branchId, branchName) {
    $("#updateBranchId").val(branchId);
    $("#updateBranchName").val(branchName);
    $("#updateBranchModal").modal("show");
}

// 📌 Şube Silme İşlemi
function deleteBranch(branchId) {
    let token = localStorage.getItem("token");
    if (!confirm("Bu şubeyi silmek istediğinizden emin misiniz?")) return;

    $.ajax({
        url: `/api/branch/${branchId}`,
        type: "DELETE",
        headers: { "Authorization": `Bearer ${token}` },
        success: function () {
            alert("Şube başarıyla silindi!");
            $("#branchesTable").DataTable().ajax.reload();
        },
        error: function (err) {
            alert("Hata oluştu: " + err.responseText);
        }
    });
}

// 📌 Şube Detay Sayfasına Git (Şu an boş, daha sonra detay işlemi eklenecek)
function viewBranch(branchId) {
    console.log(`Şube Detayına Git: ${branchId}`);
}
