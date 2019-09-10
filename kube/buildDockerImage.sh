#!/bin/bash

docker build -t alexmickelson/sudonet:0.3 -f ../Sudo/Dockerfile ..

docker push alexmickelson/sudonet:0.3
