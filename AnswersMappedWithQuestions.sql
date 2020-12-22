# SQL Test Assignment

#Attached is a mysqldump of a database to be used during the test.
#Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.



#— Test Starts Here —**

#1. Select users whose id is either 3,2 or 4
# Please return at least: all user fields

Select * from users where id In (3,2,4);


#2. Count how many basic and premium listings each active user has
#Please return at least: first_name, last_name, basic, premium

Select users.first_name,users.last_name,  COUNT(IF(listings.status = 2, 1, NULL)) 'BASICS' ,COUNT(IF(listings.status = 3,1,NULL)) 'PREMIUM' FROM users INNER JOIN listings ON users.id = listings.user_id Where users.status = 2 Group by listings.user_id ;


#3. Show the same count as before but only if they have at least ONE premium listing
# Please return at least: first_name, last_name, basic, premium

Select users.first_name,users.last_name,  COUNT(IF(listings.status = 2, 1, NULL)) 'BASICS' ,COUNT(IF(listings.status = 3,1,NULL)) 'PREMIUM' FROM users INNER JOIN listings ON users.id = listings.user_id Where users.status = 2 Group by listings.user_id HAVING COUNT(IF(listings.status = 3,1,NULL)) > 0 ;

#4. How much revenue has each active vendor made in 2013
# Please return at least: first_name, last_name, currency, revenue

Select users.first_name,users.last_name, clicks.currency, SUM(clicks.price) 'REVENUE' from users INNER JOIN  listings ON users.id = listings.user_id INNER JOIN clicks ON listings.id = clicks.listing_id WHERE users.status = 2  AND year(clicks.created) = '2013' GROUP BY listings.user_id ;


#5. Insert a new click for listing id 3, at $4.00
# Find out the id of this new click. Please return at least: id


INSERT INTO clicks (listing_id,price,currency,created) VALUES (3,4.00,'USD',current_date());
SELECT LAST_INSERT_ID();

#6. Show listings that have not received a click in 2013
# Please return at least: listing_name

SELECT distinct listings.name 'listing_name' from listings INNER JOIN clicks ON listings.id = clicks.listing_id WHERE YEAR(clicks.created) != 2013;


#7. For each year show number of listings clicked and number of vendors who owned these listings
# Please return at least: date, total_listings_clicked, total_vendors_affected

Select clicks.created,COUNT(*) as 'total_listings_clicked' from clicks  group by year(created) ;

#8. Return a comma separated string of listing names for all active vendors
# Please return at least: first_name, last_name, listing_names
Select first_name,last_name,group_concat(first_name) 'listing_names' from users where status = 2 ;