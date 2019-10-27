# gilded-rose-kata
First attempt at Gilded Rose kata in C#

Full requirements at the time being can be found in GildedRoseRequirements.txt


# NOTES

There are some uncertainties in the requirements specification.

1. Requirment: "Once the sell by date has passed, Quality **degrades** twice as fast"

One would think that per this requirement only the degradation should be multiplied. However in the initial implementation the rate is also increased for special items such as Aged Brie which does not degrade but gain quality by each iteration.

2. Requirement for new feature: "'Conjured' items degrade in Quality twice as fast as normal items"

It is not stated if only regular items can be "Conjured" or there can be special "Conjured" items like "Conjured Adged Brie". As it is impossible to clarify this, it is asumed the only regular items can be "Cojured".
