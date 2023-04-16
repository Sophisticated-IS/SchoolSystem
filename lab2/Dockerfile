# docker build -t Front:end
# docker run -it -p 3000:3000 Front:end
FROM node:18.16.0
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
COPY package.json ./
COPY package-lock.json ./
RUN npm install --silent
RUN npm install react-scripts@4.0.3 -g --silent
COPY . ./
CMD ["npm", "start"]