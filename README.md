# gRPCDemo 

# Makale 

* https://grpc.io/docs/languages/python/basics/
* https://realpython.com/python-microservices-grpc/
* https://towardsdatascience.com/implementing-grpc-server-using-python-9dc42e8daea0

# Video
* https://www.youtube.com/watch?v=D2mP5vWtVL4
* https://www.youtube.com/watch?v=MdPpnZUYLwU
* https://www.youtube.com/watch?v=0RbfCz_mlAA
* https://www.youtube.com/watch?v=MV8ZCm3EoP4

# Output 
* python -m grpc_tools.protoc -I ../protobufs --python_out=. \   --grpc_python_out=. ../protobufs/recommendations.proto

# My Env
* python -m grpc_tools.protoc -I protobufs --python_out=.   --grpc_python_out=. protobufs/user.proto  


# Info
* Stub — First of them — Stub and in our case EchoStub - is a class used by the client to connect to gRPC service
* Servicer — In our case EchoServicer - is used by the server to implement the gRPC service
* Registration Function — Finally piece, add_EchoServicer_to_server that is needed to register servicer with gRPC server.
