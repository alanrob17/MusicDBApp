# Introduction

This is my Music Database. It contains all the code to display a listing my my digital music. It has a number of routines to add, update and delete albums in the database.

The MusicDB consists of three parts.

## MusicDAL

Is the database backend. It contains the routines to get and push new data to and from the database. This version uses Dapper as the ORM.

## MusicDB

Is the ASP.Net Web Forms browser application that displays the data and contains forms to display and update the data. It retrieves its data from ``MusicDAL``.

## MusicTest

Is the testing backend for the data routines. This is a console program that I use to create and test routines for data access. The code from here eventually makes its way in to ``MusicDB``.

## Future Tasks

Eventually I will need to update this application to add a REST API for data access.
