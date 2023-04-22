FROM node:18.16.0 AS base
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH

# install dependencies
COPY /lab2/package*.json ./
RUN npm install 

FROM base as build
WORKDIR /app
COPY /lab2/public /app/public
COPY /lab2/src /app/src
COPY . .


FROM build as final
WORKDIR /app
EXPOSE 3000
CMD ["npm", "start"]