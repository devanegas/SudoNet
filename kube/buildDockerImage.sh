#!/bin/bash

docker build -t alexmickelson/sudonet -f ../Sudo/Dockerfile ..

docker push alexmickelson/sudonet