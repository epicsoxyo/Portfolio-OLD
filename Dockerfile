FROM alpine:latest

COPY ./Portfolio/ /var/www/

EXPOSE 6969 

# Install Brotli
RUN apk --no-cache add nginx-mod-http-brotli

# Installing nginx
RUN apk --no-cache add nginx


# Copy nginx config
COPY ./nginx/remote/site.conf /etc/nginx/conf.d/site.conf 
COPY ./nginx/remote/site.conf /etc/nginx/sites-enabled/default
COPY ./nginx/nginx.conf /etc/nginx

# Copy entrypoint script and give privilege to execute 
COPY entrypoint.sh /var/app/entrypoint.sh
RUN chmod -R 777 /var/app/entrypoint.sh

# Exposing nginx port
EXPOSE 80

# Invoke entrypoint.sh 
CMD ["/var/app/entrypoint.sh"]
