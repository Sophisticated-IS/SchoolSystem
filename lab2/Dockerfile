FROM node:latest
WORKDIR /app
COPY package.json ./
RUN apt-get update && apt-get install -y npm
COPY . .
CMD ["npm", "start"]