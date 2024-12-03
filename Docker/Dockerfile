FROM nginx:latest

COPY ./Docker/nginx/nginx.conf /etc/nginx/nginx.conf
COPY ./Docker/nginx/default.conf /etc/nginx/conf.d/default.conf 

COPY ./Portfolio/index.html /var/www/portfolio/index.html
COPY ./Portfolio/Build /var/www/portfolio/Build
COPY ./Portfolio/TemplateData /var/www/portfolio/TemplateData

