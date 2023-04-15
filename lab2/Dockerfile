#FROM node:14-alpine
#
#ENV PATH /lab2/node_modules/.bin:$PATH
#
#WORKDIR /lab2
#
#COPY /lab2/package.json ./
#
#COPY /lab2/package-lock.json ./
#
#RUN npm install
#
#COPY . ./
#
#CMD ["npm", "start"]


FROM node:13.12.0-alpine as builder
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
COPY package.json ./
COPY package-lock.json ./
RUN npm install --silent
RUN npm install react-scripts@4.0.3 -g
COPY . ./
CMD ["npm", "start"]