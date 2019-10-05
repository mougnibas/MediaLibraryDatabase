<> Copyright © 2019 Yoann MOUGNIBAS
<> 
<> This file is part of MediaLibraryDatabase.
<> 
<> MediaLibraryDatabase is free software: you can redistribute it and/or modify
<> it under the terms of the GNU General Public License as published by
<> the Free Software Foundation, either version 3 of the License, or
<> (at your option) any later version.
<> 
<> MediaLibraryDatabase is distributed in the hope that it will be useful,
<> but WITHOUT ANY WARRANTY; without even the implied warranty of
<> MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
<> GNU General Public License for more details.
<> 
<> You should have received a copy of the GNU General Public License
<> along with MediaLibraryDatabase.  If not, see <https://www.gnu.org/licenses/>.

# Media Library Database

An application to maintain a database of media library, such as TV Shows or movies.

# For developers

## Requirements

### SDK

`.NET Core SDK 3.0 (or higher)`

### The Movie Database API key

`dotnet user-secrets set tmdb.apiKey YourApiKeyFromTMDB --project main/scrapper`

### General

All test file must be encoded in UTF-8 (without BOM), in Windows (CR LF) end of line convention.

## Build

`dotnet build`

## Test

`dotnet test`

## Package

`dotnet publish --configuration Release`
