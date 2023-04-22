FROM node:18.16.0
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
COPY /lab2/package.json ./
COPY /lab2/package-lock.json ./
COPY /lab2/public /app/public
COPY /lab2/src /app/src
RUN npm install --silent
RUN npm install react-scripts@4.0.0 -g 

COPY . ./
CMD ["npm", "start"]