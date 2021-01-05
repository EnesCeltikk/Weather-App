1.	Hava durumu sorgulama istemcisi;  
a.	Sorgulama başlatabilmek için konsoldan bir şehir ismi okunur.  
b.	Alınan şehir ismi ile bir sorgulama isteği oluşturur ve DB’ye kayıt edilir. (Castle.ActiveRecord & NHibernate)  
c.	WCF servisinin Query metodunu çağırılır. Yanıtın durumuna uygun olarak DB kaydı güncellenir.  
d.	Hava durumu servis uygulamasının mesaj kuyruğuna aktardığı veriler ayrı bir thread ile birer birer çekilir.  
e.	Elde edilen hava durumu bilgisi DB Model sınıfına map edilir. (AutoMapper)  
f.	DB Model nesnesi kayıt edilir. (Castle.ActiveRecord, NHibernate)  
g.	Yanıt içeriğindeki şehir bilgisine veya id’sine uygun sorgulama isteği (b maddesinde kayıt edilen) DB’den bulunur. Durumu, sorgulama tarihi, yanıt Id değerleri güncellenir.  


2.	Hava durumu servis uygulaması;  
a.	Self host WCF servisi olarak çalışır. İki metot içerir.   
i.	Servisin durumunun sorgulanması için GetStatus()  
ii.	Hava durumu sorgulaması için Query(cityName)  
b.	Query metoduna gelen istekler yerel bir kuyruğa alınır.  
c.	Uygulamada ayrı bir thread ile yerel kuyruktan istekler birer birer çekilip sorgulanır.  
d.	Canlı hava durumu bilgileri paylaşan bir servis (https://openweathermap.org/api) ile şehirler sorgulanır.  
e.	API’ın yanıt içeriğine uygun DTO modeli oluşturulur.  
f.	Hava durumu bilgisini içeren model mesaj kuyruğuna aktarılır. (MSMQ)  
 
