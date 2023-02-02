# Test cases

# Requirements

a. Each subway connection (edge) is undirected.
b. Each subway connection is coloured as part of a subway line.
c. An adjacent pair of subway stations may have multiple subway connections differentiated by colour.
d. Each subway station (vertex) stores its connections (edges) to adjacent stations in a linked list.
e. Using a breadth-first search, the ShortestRoute method outputs the shortest sequence of subway.
stops (including transfers) between the two given stations.

## Insert station:
valid:
station does not exist.

invalid:
station does exist.

## Insert connection:
valid:
both stations exist.
connection with same color does not exist.
connection with same stations and different line color exists.

invalid:
One or both stations do not exist.
connection with same color does exist.

the connection is undirected.

## Remove connection:
valid:
both stations exist.
connection with matching color exists.

invalid:
One or both stations do not exist.
connection with same color doesn't exist.

what it does:
Removes both of the corresponding nodes in the list of stations.

## Remove station:
valid:
station exists.

invalid:
station does not exist.

what it does:
all edges to the station are removed, the station itself is removed

## Shortest Route:

Valid:
stations exist.
stations are connected.
stations are not the same.




