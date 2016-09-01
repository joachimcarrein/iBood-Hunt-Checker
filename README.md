# iBood-Hunt-Checker
iBood Hunt Checker

This tool will read the JSON files of iBood to show the offers offline.
This allows to let the tool run in the background and show a popup whenever a new offer is available, 
instead of having to keep a browser open and keep an eye on it.

# Configuration
## Subsites.XML
Allows to work with the different "subsites" of iBood. Should contain all available subsites already.
- ID: Custom Name
- Text: subsite url name without country code

## Custom Config
If you want to work with another country, change the country code in the file
country code can be found in these settings:
- OffersLocation
- StockLocation

Description of properties. Except for country code should all be set OK.
- OffersLocation: Location of offer json. 
- StockLocation: Location of stock json.
- IDKey: Key of the ID information
- IDStart: start tag of the IDKey
- IDEnd: end tag of the IDKey
- TitleKey: Key of the Title Information
- TitleStart: start tag of the TitleKey
- TitleEnd: end tag of TitleKey
- ImageKey: Key of the Image Key
- ImageStart: start tag of ImageKey
- ImageEnd: end tag of ImageKey
- PermalinkKey: Key of the Permalink information
- PermalinkStart: start tag of PermalinkKey
- PermalinkEnd: end tag of PermalinkKey
- OldPriceKey: Key of the Old Price information
- OldPriceStart: start tag of the OldPriceKey
- OldPriceEnd: end tag of the OldPriceKey
- NewPriceKey: Key of the New Price information
- NewPriceStart: start tag of the NewPriceKey
- NewPriceEnd: end tag of the NewPriceKey
- StockStart: start tag of the Stock information
- StockEnd: end tag of the Stock information

User Specific settings:
- CheckInterval: default 5 seconds, can be changed in the program
