import grpc
import user_pb2
import user_pb2_grpc
from concurrent import futures


class User(user_pb2_grpc.UserServiceServicer):

    def GetUserInfo(self, request, context):
        print(request)
        return user_pb2.UserInfo(age=32, address="Test", phoneNumber="55555555555")



def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    user_pb2_grpc.add_UserServiceServicer_to_server(
        User(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("Server side is waiting request!")
    server.wait_for_termination()


if __name__ == '__main__':
    serve()