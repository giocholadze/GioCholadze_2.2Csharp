SELECT model, speed, hd FROM PC WHERE price < 500

SELECT DISTINCT(maker) FROM PRODUCT WHERE type = 'printer'

SELECT model, ram, screen FROM Laptop WHERE price > 1000

SELECT code, model, color, type, price FROM  Printer WHERE color = 'y'

SELECT model, speed, hd FROM PC WHERE price < 600 AND (cd = '12x' OR cd = '24x')

SELECT DISTINCT(maker), speed FROM laptop AS l
RIGHT JOIN Product AS p
ON p.model = l.model
WHERE hd > 9

SELECT P.model, price FROM PRODUCT P
JOIN Laptop L
ON P.MODEL = L.MODEL
WHERE maker = 'b'
UNION
SELECT P.model, price FROM PRODUCT P
JOIN PC 
ON P.MODEL = PC.MODEL
WHERE maker = 'b'
UNION
SELECT P.model, price FROM PRODUCT P
JOIN Printer PR
ON P.MODEL = PR.MODEL
WHERE maker = 'b'

SELECT DISTINCT(maker) FROM Product
WHERE type = 'PC' AND maker NOT IN (SELECT maker FROM Product WHERE type = 'Laptop')

SELECT DISTINCT(maker) FROM Product
JOIN PC
ON Product.model = PC.model
WHERE PC.speed > 449

SELECT model, price FROM Printer
WHERE price in (SELECT MAX(price) from Printer)

SELECT AVG(speed) FROM PC

SELECT AVG(speed) FROM Laptop WHERE price > 1000

SELECT AVG(speed) FROM PC
JOIN Product p
ON p.model = PC.model
WHERE maker = 'a'

SELECT l.class, l.name, p.country FROM Ships AS l
LEFT JOIN Classes AS p
ON p.class = l.class
WHERE p.numGuns > 9


SELECT DISTINCT(hd) FROM PC GROUP BY hd HAVING COUNT(hd)>1

meteqvsmete ar sheinaxa ver movaswari tavidan dawera

