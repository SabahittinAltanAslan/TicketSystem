document.addEventListener("DOMContentLoaded", async function () {
    console.log("Grafik yükleme başladı...");

    // 📌 API'den "Problemler" verisini çek
    await fetch("/api/statistics/problems")
        .then(response => response.json())
        .then(data => {
            console.log("Problem verileri yüklendi:", data);

            var ctx1 = document.getElementById('problemsChart').getContext('2d');
            new Chart(ctx1, {
                type: 'bar',
                data: {
                    labels: data.labels, // API'den gelen başlıklar
                    datasets: [{
                        label: 'Çözülen Problemler',
                        data: data.values, // API'den gelen sayılar
                        backgroundColor: [
                            'rgba(54, 162, 235, 0.7)',
                            'rgba(255, 206, 86, 0.7)',
                            'rgba(75, 192, 192, 0.7)'
                        ],
                        borderColor: [
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)'
                        ],
                        borderWidth: 1
                    }]
                }
            });
        })
        .catch(error => console.error("Problem verileri yüklenirken hata oluştu:", error));

    // 📌 API'den "Şube Arıza Dağılımı" verisini çek
    await fetch("/api/statistics/branches")
        .then(response => response.json())
        .then(data => {
            console.log("Şube verileri yüklendi:", data);

            var ctx2 = document.getElementById('branchesChart').getContext('2d');
            new Chart(ctx2, {
                type: 'pie',
                data: {
                    labels: data.labels, // API'den gelen şube isimleri
                    datasets: [{
                        data: data.values, // API'den gelen yüzdelik oranlar
                        backgroundColor: [
                            'rgba(54, 162, 235, 0.7)',
                            'rgba(255, 206, 86, 0.7)',
                            'rgba(75, 192, 192, 0.7)'
                        ],
                        borderColor: [
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
            });
        })
        .catch(error => console.error("Şube verileri yüklenirken hata oluştu:", error));
});
