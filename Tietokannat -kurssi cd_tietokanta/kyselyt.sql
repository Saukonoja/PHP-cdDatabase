- BASIC QUERIES---------------------

-- Kaikki artistit tulostetaan

select 
	esittaja.nimi as Esittaja,
	vuosi.vuosi as Perustamisvuosi,
	maa.nimi as Maa
from esittaja 
left join vuosi on esittaja.vuosi_avain = vuosi.avain
left join maa on esittaja.maa_avain = maa.avain;


-- Kaikki albumit tulostetaan

select 
	cd.nimi as Levy,
	esittaja.nimi as Esittaja,
	vuosi.vuosi as Julkaisuvuosi,
	yhtio.nimi as Yhtio
from cd 
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain;


-- Kaikki kappaleet tulostetaan

select 
		kappale.nimi as Kappale,
		esittaja.nimi as Esittaja,
		cd.nimi as Levy,
		vuosi.vuosi as Julkaisuvuosi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join esittaja on kappale.esittaja_avain = esittaja.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain;


-- Kaikki genret tulostetaan

select 
	genre.nimi as Genre 
from genre;


-- Kappaleet tulostetaan aakkosjärjestyksessä genren mukaan

select 
	kappale.nimi as Kappale,
	genre.nimi as Genre
from kappale
left join kappale_genre on kappale_genre.kappale_avain = kappale.avain
left join genre on kappale_genre.genre_avain = genre.avain
ORDER BY genre.nimi, kappale.nimi


-- Kaikki levy-yhtiöt tulostetaan

select 
		yhtio.nimi as Levyyhtio,
		maa.nimi as Maa,
		vuosi.vuosi as Perustamisvuosi
from yhtio
left join maa on yhtio.maa_avain = maa.avain
left join vuosi on yhtio.vuosi_avain = vuosi.avain;


-- Kaikki artistin levyt tulostetaan

select 
	cd.nimi as Levy,
	esittaja.nimi as Esittaja,
	vuosi.vuosi as Julkaisuvuosi,
	yhtio.nimi as Yhtio
from cd
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain
where cd_esittaja.esittaja_avain = (select avain from esittaja where nimi = 'Europe');


-- Kaikki levyn kappaleet tulostetaan

select 
		kappale.nimi as Kappale,
		kappale.kesto as Kesto,
		cd.nimi as Levy,
		vuosi.vuosi as Julkaisuvuosi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'The Final Countdown');


-- ADVANCED QUERIES--------------------


-- Albumin kappaleiden kestojen keskiarvo tulostetaan

select
		avg(kappale.kesto)
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'The Final Countdown');


-- Kaikki albumin kappaleet, joiden kesto on alle 5 minuuttia tulostetaan keston mukaan järjestyksessä

select
		kappale.nimi as kappale,
		kappale.kesto as kesto,
		cd.nimi as levy
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'The Final Countdown')
and kappale.kesto < 300
order by kappale.kesto;


-- Kaikki artistit, jonka jollain albumilla on yli kymmenen kappaletta 

select
		nimi
from esittaja as e 
inner join cd_esittaja as cde on e.avain = cde.esittaja_avain
where cd_avain in 
  (
	select cd_avain
	from cd_kappale
	group by cd_avain
	having count(kappale_avain) > 10
  )


-- Albumin nimi tulostetaan ja kappalemäärä, jos levyllä on yli 10 kappaletta

select 
		cd.nimi as levy,
		count(kappale.nimi) as kappaleita
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd.nimi = 'Fear of the Dark' 
group by cd.nimi
having count(kappale.nimi) > 10;  


-- Albumin kappaleet sekoitetaan ja valitaan aina yksi näkyviin, voisi toimia esimerkiksi albumia kuunneltaessa ns. shufflena

select
top 1
  kappale.nimi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'Fear of the Dark')
ORDER BY NEWID() 


-- Etsitään taulusta cd, sen nimisiä albumeita joiden nimessä esiintyy jossain kohtaa kirjain 'F'


select
 * 
from cd 
where cd.nimi like '%F%'; 


-- Etsitään taulusta hakusanalla

select 
  cd.nimi as Levy,
  esittaja.nimi as Esittaja,
  vuosi.vuosi as Julkaisuvuosi,
  yhtio.nimi as Yhtio
from cd 
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain
where cd.nimi like '%1986%' or esittaja.nimi like '%1986%' or vuosi.vuosi like '%1986%' or yhtio.nimi like '%1986%' 


-- Staattinen pivot tulostaa montako albumia levy-yhtiö on julkaissut tiettynä vuonna

select 
	*
from (
	select 
		vuosi.vuosi,
		yhtio.nimi as yhtionimi,
		cd.nimi as cdnimi
	from cd
	inner join yhtio on cd.yhtio_avain = (select avain from cd where yhtio_avain = cd.avain)
	inner join vuosi on cd.vuosi_avain = vuosi.avain
) as tt
pivot (COUNT(cdnimi) for vuosi in ([1986],[1992])) P



-- Dynaaminen pivot tulostaa montako albumia levy-yhtiö on julkaissut tiettynä vuonna

DECLARE @DynamicPivotQuery AS NVARCHAR(MAX)
DECLARE @ColumnName AS NVARCHAR(MAX)

--Get distinct values of the PIVOT Column 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(vuosi)
FROM (SELECT DISTINCT vuosi FROM (
	select 
		vuosi.vuosi,
		yhtio.nimi as yhtionimi,
		cd.nimi as cdnimi
	from cd
	inner join yhtio on cd.yhtio_avain = (select avain from cd where yhtio_avain = cd.avain)
	inner join vuosi on cd.vuosi_avain = vuosi.avain
) as tt) AS C
 
--Prepare the PIVOT query using the dynamic 
SET @DynamicPivotQuery = 
  N'SELECT *
    FROM (select 
		vuosi.vuosi,
		yhtio.nimi as yhtionimi,
		cd.nimi as cdnimi
	from cd
	inner join yhtio on cd.yhtio_avain = (select avain from cd where yhtio_avain = cd.avain)
	inner join vuosi on cd.vuosi_avain = vuosi.avain) as tt
    PIVOT(COUNT(cdnimi) 
          FOR vuosi IN (' + @ColumnName + ')) AS PVTTable'
--Execute the Dynamic Pivot Query
EXEC sp_executesql @DynamicPivotQuery
