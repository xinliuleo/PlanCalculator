# base image
FROM node:10.16.2-alpine AS builder

WORKDIR /app
COPY . .
RUN yarn install
RUN yarn run build

FROM node:10.16.2-alpine
RUN yarn global add serve
WORKDIR /app
COPY --from=builder /app/build .
CMD ["serve", "-p", "3000", "-s", "."]
