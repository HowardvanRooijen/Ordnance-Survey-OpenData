Ordnance Survey OpenData Sources
================================

About
=====

This project contains various Ordnance Survey OpenData Sources processed from their raw CSV form.

For more info see: 

http://www.ordnancesurvey.co.uk/oswebsite/opendata/ 
http://data.ordnancesurvey.co.uk/ 
http://parlvid.mysociety.org:81/os/ 

The project directory structure is listed below:

Code-Point Open
===============

This directory contains processed data dumps of the Code-Point Open Datasets - see http://www.ordnancesurvey.co.uk/oswebsite/products/code-point-open/index.html for more info.

Datasets available:

MongoDB
-------

There are two datasets for MongoDB, both are in 7Zip compression format: http://www.7-zip.org/

OS-Code-Point-Open-MongoDB-Dump.7z - use mongorestore.exe to import
OS-Code-Point-Open-MongoDB-JSON-Export.7z - use mongoimport to import (then manually build the indexes):

>db.PostCodes.ensureIndex({ PostCode : 1 })
>db.PostCodes.ensureIndex({ loc : '2d' })

You can then query using the following commands:

>db.PostCodes.find({ PostCode: 'AB101AA' })
>db.PostCodes.find({ loc : [-2.096647896, 57.14823188] })
>db.runCommand({ geoNear : "PostCodes", near : [-2.096647896, 57.14823188], num : 10 });

SQL2005
-------

A Microsoft SQL Server 2005 table script containing the data in the following columns: 

[PostCode]  [varchar](9),
[Longitude] [decimal](18, 15),
[Latitude]  [decimal](18, 15)

Script is in 7Zip compression format: http://www.7-zip.org/

SQL2008
------- 

A Microsoft SQL Server 2008 table script containing the data in the following column:

[PostCode]   [varchar](9) NOT NULL,
[Coordinate] [geography] NOT NULL

Script is in 7Zip compression format: http://www.7-zip.org/

License:
========

This data contains Ordnance Survey data (c) Crown copyright and database right 2010. 
Code-Point Open contains Royal Mail data (c) Royal Mail copyright and database right 2010.

Data may be used under the terms of the OS OpenData licence: http://parlvid.mysociety.org:81/os/licence.pdf