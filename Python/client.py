from __future__ import print_function
import logging
from os import name

import grpc

import user_pb2
import user_pb2_grpc


def run():
    with grpc.insecure_channel('localhost:50051') as channel:
        stub = user_pb2_grpc.UserServiceStub(channel)
        response = stub.GetUserInfo(user_pb2.User(id=1, name="ishakdolek"))
    print(response)


if __name__ == '__main__':
    logging.basicConfig()
    run()
