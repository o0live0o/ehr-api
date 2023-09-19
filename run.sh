image_name="ehr:$1"
docker stop ehr-8060
docker rm ehr-8060
docker build -t $image_name .
docker run -itd --name=ehr-8060 -p 8060:80 --restart=always $image_name
