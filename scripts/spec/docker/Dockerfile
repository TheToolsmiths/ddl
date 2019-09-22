FROM openjdk:8-jre-alpine

ENV ANTLR_VERSION 4.7.2
ENV CLASSPATH .:/antlr/antlr-${ANTLR_VERSION}-complete.jar:$CLASSPATH

ADD http://www.antlr.org/download/antlr-${ANTLR_VERSION}-complete.jar /usr/local/lib/
RUN chmod +r /usr/local/lib/antlr-${ANTLR_VERSION}-complete.jar

RUN mkdir /antlr-out
RUN mkdir /antlr

COPY /antlr.sh /usr/bin/antlr
RUN chmod +x /usr/bin/antlr

ENTRYPOINT ["/usr/bin/antlr"]