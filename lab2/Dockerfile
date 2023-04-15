FROM node:14-alpine

ENV PATH /app/node_modules/.bin:$PATH

WORKDIR /app

COPY /lab2/package.json ./

COPY /lab2/package-lock.json ./

RUN npm install

COPY . ./

CMD ["npm", "start"]