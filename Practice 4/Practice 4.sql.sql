1
SELECT model, speed, hd FROM PC WHERE price < 500

2
SELECT DISTINCT(maker) FROM PRODUCT WHERE type = 'printer'

3
SELECT model, ram, screen FROM Laptop WHERE price > 1000

4
SELECT code, model, color, type, price FROM  Printer WHERE color = 'y'

5
SELECT model, speed, hd FROM PC WHERE price < 600 AND (cd = '12x' OR cd = '24x')

6
SELECT DISTINCT(maker), speed FROM laptop AS l
RIGHT JOIN Product AS p
ON p.model = l.model
WHERE hd > 9

7
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

8
SELECT DISTINCT(maker) FROM Product
WHERE type = 'PC' AND maker NOT IN (SELECT maker FROM Product WHERE type = 'Laptop')

9
SELECT DISTINCT(maker) FROM Product
JOIN PC
ON Product.model = PC.model
WHERE PC.speed > 449

10
SELECT model, price FROM Printer
WHERE price in (SELECT MAX(price) from Printer)

11
SELECT AVG(speed) FROM PC

12
SELECT AVG(speed) FROM Laptop WHERE price > 1000

13
SELECT AVG(speed) FROM PC
JOIN Product p
ON p.model = PC.model
WHERE maker = 'a'

14
SELECT l.class, l.name, p.country FROM Ships AS l
LEFT JOIN Classes AS p
ON p.class = l.class
WHERE p.numGuns > 9

15
SELECT DISTINCT(hd) FROM PC GROUP BY hd HAVING COUNT(hd)>1

16
SELECT p2.model, p1.model, p1.speed, p1.ram
FROM PC p1
JOIN PC p2 ON p1.speed = p2.speed AND p1.ram = p2.ram
WHERE p1.model < p2.model

17
SELECT p.type, l.model, l.speed
FROM Laptop l
JOIN Product p ON l.model = p.model
WHERE l.speed < ALL (SELECT p2.speed FROM PC p2)

18
SELECT DISTINCT B.maker, A.price
FROM Printer A
JOIN Product B
ON B.model = A.model
WHERE A.color = 'Y'
AND A.price = (SELECT MIN(price) FROM Printer WHERE color = 'Y');

19
SELECT P.maker, AVG(L.screen) AS avg_screen_size
FROM Product P, Laptop L
WHERE P.model = L.model
GROUP BY P.maker

20 
SELECT maker, COUNT(DISTINCT model) AS Count_Model
FROM Product
WHERE type = 'pc'
GROUP BY maker
HAVING COUNT(DISTINCT model) > 2

