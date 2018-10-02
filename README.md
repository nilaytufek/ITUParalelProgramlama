# ITUParalelProgramlama
ITU BLG 503 Paralel programlama dersinin projesidir. C# dilinde yazılmıştır. Ayrıntıları raporda ve kodda görebilirsiniz.

Proje Tanımı: 
Bir banka şubesindeki çalışma düzeni gerçeklenecektir. Şubede n adet (örneğin, n=4)
banka görevlisi hizmet vermektedir. Müşteriler şubeye girdikten sonra, sıra numarası almak üzere,
bir anda bir müşteriye hizmet verebilen bir cihaz kullanırlar. Cihaz iki türlü numara vermektedir:
banka kartı ile istekte bulunan müşterilere hizmet alma önceliği yüksek olan ayrıcalıklı bir sıra
numarası; bu tür bir kart kullanmayanlara ise normal bir sıra numarası. Müşteri, sıra numarasını
aldıktan sonra bir panelde numarası görüntülenene kadar bekler. Şubede m adet (örneğin, m=10)
bekleme koltuğu bulunmaktadır. Bir anda bekleyen müşteri sayısı en fazla m+5 (m adet oturan +
5 adet ayakta) olabilir. Şubenin girişinde bulunan güvenlik görevlisi, bekleyen müşteri sayısı
m+5’e ulaşınca, yeni müşterilerin şubeye girişlerini engeller. Bu şekilde engellenen müşteriler
dışarıda bekleyebilirler veya daha sonra gelmek üzere bankayı terkederler. Bir banka görevlisi
hizmete hazır olduğu zaman bekleyen müşterilerden sırası geleni seçmek üzere bir butona basar.
Numarası seçilip panelde görüntülenen müşteri işlemlerini yaptırır ve bankayı terkeder. Her
görevli kendine ait bir butona sahiptir. Birden fazla görevli aynı anda butonuna basması halinde
sadece birinin işlemi yapılmalı, diğerleri bekletilmelidir. Sıra numarası seçimi normal ve
ayrıcalıklı müşteriler arasında yapılır ve aşağıda verilen kurallar uygulanır:
1. Hiç ayrıcalıklı müşteri yok ise, sıradaki müşteriyi seç.
2. Bir ayrıcalıklı müşteriye, kendinden once gelen 2 normal müşteriye göre öncelik tanı.
3. Daha önce gelmiş ve beklemekte olan normal müşteri var ise, ard arda ikiden fazla
ayrıcalıklı müşteriye hizmet verme.
Müşteri ve banka görevlilerinin ayrı ayrı prosesler olarak temsil edildiği, yukarıda belirtilen
çalışma düzenini gerçekleyen bir paralel program geliştirin. Uygulama ortamının seçimi öğrenci
tarafından yapılacaktır. Uygulama ortamı olarak paralel çalışmaya destek verecek bir çalışma
ortamı (Java-thread, Unix-prosesler, MPI, vs.) seçilebilir. Programın çalışma sürecini ekrana
anlaşılır şekilde yansıtan bir çıkış üretmeniz beklenmektedir. Çalışma bir rapor eşliğinde
sunulacaktır. Raporda, karşılaşılan problemler ve çözüm algoritmaları ayrıntılı olarak
anlatılmalıdır.
