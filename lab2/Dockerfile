# docker build -t Front:end
# docker run -it -p 3000:3000 Front:end
FROM node:18.16.0
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
COPY /lab2/package.json ./
COPY /lab2/package-lock.json ./
COPY /lab2/public ./app/public
RUN npm install --silent
RUN npm install react-scripts@4.0.0 -g 
COPY . ./
CMD ["npm", "start"]