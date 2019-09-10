#!/bin/bash

docker build -t alexmickelson/sudonet:0.6 -f ../Sudo/Dockerfile ..

docker push alexmickelson/sudonet:0.6
