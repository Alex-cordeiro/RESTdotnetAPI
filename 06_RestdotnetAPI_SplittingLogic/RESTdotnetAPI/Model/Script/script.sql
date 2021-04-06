CREATE DATABASE rest_with_asp_net_udemy;

use rest_with_asp_net_udemy;


show tables;



CREATE TABLE person (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  address varchar(100) NOT NULL,
  first_name varchar(80) NOT NULL,
  last_name varchar(80) NOT NULL,
  gender varchar(6) NOT NULL,
  PRIMARY KEY (id));